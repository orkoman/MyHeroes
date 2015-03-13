function clMan(_id, _map)
{
    this.m_size = 16;

    this.m_divObject = document.getElementById(_id);
    this.m_map = _map;

    this.m_divObject.style.visibility = 'hidden';
    this.m_position = 0;//_position;
    this.m_p2Position = 0;//position_toXY(_position,this.m_map.m_size,this.m_size,this.m_size*2);
    this.m_speed = 200;

    this.m_action = 0;//new clAction_Born(this);

    this.f_draw = draw;
    this.f_doSomething = doSomething;
    this.f_setAction = setAction;

    this.f_setAction(new clAction_Born(this))
    this.f_draw();

    function setAction(_action)
    {
        this.m_action = _action;
        if (this.m_action != 0) {
            this.m_action.f_init();
        }
    }

    function draw()
    {
        // update object
        this.m_divObject.style.left = this.m_p2Position.m_x + "px";
        this.m_divObject.style.top = this.m_p2Position.m_y + "px";
    }

    function doSomething(t_sec)
    {
        if (this.m_action == 0)
        {
            this.f_setAction(actionFactory_getMoveAroundAction(this));
        }

        if (this.m_action.f_action(t_sec) == true) //end action
        {
            //alert(this.m_action.m_nextAction);
            this.f_setAction(this.m_action.m_nextAction);
        }

        this.f_draw();
    }

}

function actionFactory_getMoveAroundAction(_man)
{
    var doNothingActionFull = new clAction_MovePath(_man);
    doNothingActionFull.m_nextAction = new clAction_Nothing(_man,3);
    doNothingActionFull.m_nextAction.m_nextAction = doNothingActionFull;
    return doNothingActionFull;
}

function clAction_MovePath(_man)
{
    this.m_man = _man;
    this.m_nextAction = 0;

    this.f_init = init;
    this.f_action = doAction;

    function init()
    {
        var map = this.m_man.m_map;
        var mapSize = map.m_size;
        var position = this.m_man.m_position;
        var newTarget = 0;
        do
        {
            newTarget = Math.floor(Math.random() * mapSize*mapSize);
        } while (map.m_colisionMap[newTarget] != 0 || newTarget == position);

        this.m_path = getPath(map, position, newTarget);
        if (this.m_path == -2) //die
        {
            this.m_man.f_setAction(new clAction_Die(_man,5));
            //alert('die');
            return false;//false = dont change action
        }

        this.m_pathIndex = 0; //0 is start position
        this.m_p2Target = 0;
    }

    function doAction(t_sec)
    {
        //get next path
        if (this.m_p2Target == 0)
        {
            this.m_pathIndex++;
            if (this.m_pathIndex < this.m_path.length)
            {
                var man = this.m_man;
                var map = man.m_map;
                var targetPosition = this.m_path[this.m_pathIndex];

                if (map.m_colisionMap[targetPosition] == 0) {
                    this.m_p2Target = position_toXY(targetPosition, map.m_size, man.m_size - 32, man.m_size);
                }
                else
                {
                    return true; // change target, cant finish path..... //TODO need refactor, if cant reach path do something or give feedback
                }
            }
            else
            {
                return true; // finished path
            }
        }

        //calculate differences
        var dx = this.m_p2Target.m_x - this.m_man.m_p2Position.m_x;
        var dy = this.m_p2Target.m_y - this.m_man.m_p2Position.m_y;
        var len = Math.sqrt(dx*dx + dy*dy);
        var t_sec_speed = this.m_man.m_speed*t_sec;
        //end move
        if (len < t_sec_speed)
        {
            this.m_man.m_p2Position.m_x = this.m_p2Target.m_x;
            this.m_man.m_p2Position.m_y = this.m_p2Target.m_y;
            this.m_man.m_position = this.m_path[this.m_pathIndex];
            if (this.m_man.m_map.m_colisionMap[this.m_man.m_position] != 0) //die
            {
                this.m_man.f_setAction(new clAction_Die(_man,5));
                return false;//false = dont change action
            }
            this.m_p2Target = 0;
        }
        //move
        else {
            var t_sec_speed_len = t_sec_speed / len;
            dx = dx * t_sec_speed_len;
            dy = dy * t_sec_speed_len;
            if (Math.abs(dx) > Math.abs(dy))
            {
                if (dx < 0)
                {
                    this.m_man.m_divObject.style.backgroundImage = clGame.sf_getGraph("units/people_l.png");
                }
                else
                {
                    this.m_man.m_divObject.style.backgroundImage = clGame.sf_getGraph("units/people_r.png");
                }
            }
            else
            {
                if (dy < 0)
                {
                    this.m_man.m_divObject.style.backgroundImage = clGame.sf_getGraph("units/people_u.png");
                }
                else
                {
                    this.m_man.m_divObject.style.backgroundImage = clGame.sf_getGraph("units/people_d.png");
                }
            }

            this.m_man.m_p2Position.m_x += dx;
            this.m_man.m_p2Position.m_y += dy;
        }
        return false;
    }
}

function clAction_Nothing(_man,_maxTime)
{
    this.m_man = _man;
    this.m_nextAction = 0;
    this.m_time = 0;
    this.m_maxTime = _maxTime;

    this.f_init = init;
    this.f_action = doAction;

    function init()
    {
        this.m_time = 0;
        this.m_man.m_divObject.style.backgroundImage = clGame.sf_getGraph("units/people_doNothing.png");
    }

    function doAction(t_sec)
    {
        this.m_time += t_sec;
        if (this.m_time > this.m_maxTime)
        {
            return true;
        }
        return false;
    }
}

function clAction_Die(_man,_maxTime)
{
    this.m_nextAction = new clAction_Born(_man);
    this.m_man = _man;
    this.m_time = 0;
    this.m_maxTime = _maxTime;

    this.f_init = init;
    this.f_action = doAction;

    function init()
    {
        this.m_time = 0;
        this.m_man.m_divObject.style.backgroundImage = clGame.sf_getGraph("units/people_die.png");
    }

    function doAction(t_sec)
    {
        //TODO
        this.m_time += t_sec;
        this.m_man.m_p2Position.m_y -= this.m_man.m_speed/5*t_sec;
        if (this.m_time > this.m_maxTime)
        {
            return true;
        }
        return false;
    }
}

function clAction_Born(_man)
{
    this.m_nextAction = new clAction_Nothing(_man,1);
    this.m_man = _man;

    this.f_init = init;
    this.f_action = doAction;

    function init()
    {
        this.m_man.m_divObject.style.backgroundImage = clGame.sf_getGraph("units/people_muster.png");
    }

    function doAction(t_sec)
    {
        var map = this.m_man.m_map;
        var mapSize = map.m_size;
        var newTarget = 0;
        do
        {
            newTarget = Math.floor(Math.random() * mapSize*mapSize);
        } while (map.m_colisionMap[newTarget] != 0);


        this.m_man.m_position = newTarget;//_position;
        this.m_man.m_p2Position = position_toXY(this.m_man.m_position,mapSize,this.m_man.m_size - 32,this.m_man.m_size);
        this.m_man.m_divObject.style.visibility = 'visible';
        return true;
    }
}








