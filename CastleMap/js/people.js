function clMan(_id,_position, _map)
{
    this.m_size = 16;

    this.m_divObject = document.getElementById(_id);
    this.m_map = _map;

    this.m_position = _position;
    this.m_p2Position = position_toXY(_position,this.m_map.m_size,this.m_size,this.m_size*2);

    this.m_speed = 200;

    this.m_action = actionFactory_getMoveAroundAction(this);

    this.f_draw = draw;
    this.f_doSomething = doSomething;

    this.f_draw();

    function draw()
    {
        // update object
        this.m_divObject.style.left = this.m_p2Position.m_x + "px";
        this.m_divObject.style.top = this.m_p2Position.m_y + "px";
    }

    function doSomething(t_sec)
    {
        if (this.m_action.f_action(t_sec))
        {
            var nextAction = this.m_action.m_nextAction;
            if (nextAction != 0) {
                this.m_action = nextAction;
            }
            else
            {
                this.m_action = actionFactory_getMoveAroundAction(this);
            }
        }

        this.f_draw();
    }

}

function actionFactory_getMoveAroundAction(_man)
{
    var doNothingActionFull = new clAction_MovePath(_man);
    doNothingActionFull.m_nextAction = new clAction_Nothing(_man,3);
    return doNothingActionFull;
}

function clAction_MovePath(_man)
{
    this.m_man = _man;
    this.m_nextAction = 0;

    var map = this.m_man.m_map;
    var mapSize = map.m_size;
    var position = this.m_man.m_position;
    var newTarget = 0;
    do
    {
        newTarget = Math.floor(Math.random() * mapSize*mapSize);
    } while (map.m_colisionMap[newTarget] != 0 || newTarget == position);

    this.m_path = getPath(map, position, newTarget);
    this.m_pathIndex = 0; //0 is start position
    this.m_p2Target = 0;

    this.f_action = doAction;

    function doAction(t_sec)
    {
        //get next path
        if (this.m_p2Target == 0)
        {
            this.m_pathIndex++;
            if (this.m_pathIndex < this.m_path.length)
            {
                this.m_p2Target = position_toXY(this.m_path[this.m_pathIndex],this.m_man.m_map.m_size,this.m_man.m_size,this.m_man.m_size*2);
            }
            else
            {
                return true;
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
                    this.m_man.m_divObject.style.backgroundImage = "url('../img/units/people_l.png')";
                }
                else
                {
                    this.m_man.m_divObject.style.backgroundImage = "url('../img/units/people_r.png')";
                }
            }
            else
            {
                if (dy < 0)
                {
                    this.m_man.m_divObject.style.backgroundImage = "url('../img/units/people_u.png')";
                }
                else
                {
                    this.m_man.m_divObject.style.backgroundImage = "url('../img/units/people_d.png')";
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
    this.m_nextAction = 0;
    this.m_time = 0;
    this.m_maxTime = _maxTime;

    this.f_action = doAction;

    function doAction(t_sec)
    {
        //_man.m_divObject.style.backgroundImage = "url('../img/units/people_doNothing_2.png')";
        //_man.m_divObject.innerHTML = this.m_maxTime - this.m_time;
        _man.m_divObject.style.backgroundImage = "url('../img/units/people_doNothing.png')";


        this.m_time += t_sec;
        if (this.m_time > this.m_maxTime)
        {
            return true;
        }
        return false;
    }
}








