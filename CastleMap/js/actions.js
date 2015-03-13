function clActionTab(_id)
{
    this.m_actionDiv = document.getElementById(_id);
    this.m_dragObject = 0;

    this.f_createDragObject =
        function createDragObject(_buildingId,_name,_size)
        {
            this.m_actionDiv.innerHTML = "<div id = 'drag' class ='" + _name + "' onmousedown=\"map_click(event)\" ></div>";
            this.m_dragObject = new clDragObject('drag',_buildingId,_name,_size);
        }

    this.f_removeDragObject =
        function removeDragObject()
        {
            this.m_dragObject = 0;
            this.m_actionDiv.innerHTML = "";
        }

    this.f_show =
        function show(_actions, _p2Position)
        {
            if (_p2Position == -1)
            {
                _p2Position = new clPoint2(this.m_actionDiv.offsetLeft + this.m_actionDiv.offsetWidth/2,
                    this.m_actionDiv.offsetTop + this.m_actionDiv.offsetHeight/2);

            }
            //alert(_p2Position.m_x);
            var x = 5;
            var y = 5;
            var temp = "";
            var size = 0;

            var count = _actions.length;
            for(var n = 0; n < count;n++)
            {
                temp += "<div class ='" + _actions[n].m_name + "' style = 'left:" + x + "px;top:" + y + "px;' onclick=\"" + _actions[n].m_action +"\"></div>";
                var tempSize = _actions[n].m_size*64;
                x += 5 + tempSize;
                if (size < tempSize)
                {
                    size = tempSize;
                }
            }
            y += 5 + size;

            this.m_actionDiv.innerHTML = temp;

            this.m_actionDiv.style.width = x + "px";
            this.m_actionDiv.style.height = y + "px";

            this.m_actionDiv.style.left = (_p2Position.m_x - this.m_actionDiv.offsetWidth/2) + "px";
            this.m_actionDiv.style.top = (_p2Position.m_y - this.m_actionDiv.offsetHeight/2) + "px";

            //alert(temp);
        }

    this.f_close =
        function close()
        {
            this.m_actionDiv.innerHTML = "";
            this.m_actionDiv.style.width = 0 + "px";
            this.m_actionDiv.style.height = 0 + "px";
        }
}

function clDragObject(_id,_buildingId,_name,_size)
{
    this.m_buildingId = _buildingId;
    this.m_name = _name;
    this.m_dragDiv = document.getElementById(_id);
    this.m_size = _size;
}

function clActionBuild()
{
    this.m_name = "build";
    this.m_size = 0.5;
    this.m_action = "clActionBuild.sf_action()";

    clActionBuild.f_listener =
        function listener(_result)
        {
            g_Game.m_cashedBuildings = decodeData(_result,clChooseBuilding,0);
            g_Game.m_cashedBuildings[g_Game.m_cashedBuildings.length] = new clActionCancel();
            g_Game.m_actionTab.f_show(g_Game.m_cashedBuildings,-1); //-1 means same position
        }

    clActionBuild.sf_action = function action()
    {
        if (g_Game.m_cashedBuildings == 0) {
            g_Game.m_ajaxHelper.f_sendRequest(this, "1");
        }
        else
        {
            g_Game.m_actionTab.f_show(g_Game.m_cashedBuildings,-1); //-1 means same position
        }
    }
}

function clActionCancel()
{
    this.m_name = "cancel";
    this.m_size = 0.5;
    this.m_action = "clActionCancel.sf_action()";

    clActionCancel.sf_action = function action()
    {
        g_Game.m_actionTab.f_close();
    }
}

function clActionSetPeople()
{
    this.m_name = "setpeople";
    this.m_size = 0.5;
    this.m_action = "clActionSetPeople.sf_action()";

    clActionSetPeople.sf_action = function action()
    {
        //TODO
        //g_Game.m_actionTab.f_close();
    }
}

function clChooseBuilding(_dataArr,_extraArg)
{
    this.m_buildingId = _dataArr[0];
    this.m_name = _dataArr[1];
    this.m_size = _dataArr[2];

    this.m_action = "clChooseBuilding.sf_action(" + this.m_buildingId + ",'" + this.m_name + "'," + this.m_size +")";
    clChooseBuilding.sf_action = function action(_buildingId, _name,_size)
    {
        g_Game.m_actionTab.f_close();
        g_Game.m_actionTab.f_createDragObject(_buildingId,_name,_size);
        g_Game.m_map.f_showBuildingsAndNature(false);
    }
}
