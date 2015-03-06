function clGame(_buildings,nature,resources) {

    this.f_init = init;
    this.f_mainLoop = mainLoop;

    this.f_init();

    function init()
    {
        this.m_objlist = new Array();

        this.m_map = new clMap('map',20,_buildings,nature);
        this.m_objlist[0] = this.m_map;

        this.m_resourceTab = new clResourceTab('resourceTab',resources);
        this.m_actionTab = new clActionTab('actionTab');
        //this.m_objlist[1] = this.m_actionTab;

        this.m_timer = new clTimer(this.f_mainLoop,35);
        this.m_timer.f_start();
    }

    function mainLoop()
    {
        var t_milli = g_Game.m_timer.f_getDeltaTime();

        var count = g_Game.m_objlist.length;

        for(var n = 0; n < count;n++)
        {
            g_Game.m_objlist[n].f_doSomething(t_milli);
        }

    }
}

function map_click(event)
{
    event = event || window.event;

    var x = event.pageX - g_Game.m_map.m_mapDiv.offsetLeft;
    var y = event.pageY - g_Game.m_map.m_mapDiv.offsetTop;

    var isoX = Math.floor((x / 32 - y / 16) /2) + g_Game.m_map.m_size/2;
    var isoY = Math.floor((y / 16 + x / 32) /2) - g_Game.m_map.m_size/2;

    var position = isoY*g_Game.m_map.m_size + isoX;

    if (g_Game.m_map.m_colisionMap[position] != 0)
    {
        //alert(g_Map.m_colisionMap[position]);
        var element = document.getElementById(g_Game.m_map.m_colisionMap[position]);
        element.style.backgroundImage = "url('../img/grass_hover.png')";

        //TODO show buildings actions and properties
    }
    else
    {
        // get grass
        //var element = document.getElementById('f_' + position);
        //element.style.backgroundImage = "url('../img/grass_hover.png')";

        var p2Point = new clPoint2(event.pageX,event.pageY);
        var tempAction = new clActionBuild(position, 32);
        g_Game.m_actionTab.f_show(new Array(tempAction,tempAction),p2Point);


    }
    //alert(position);
}

function map_move(event)
{
    event = event || window.event;
    var dragObject = g_Game.m_actionTab.m_dragObject;
    if (dragObject != 0)
    {
        var actionTabDiv = g_Game.m_actionTab.m_actionDiv;
        actionTabDiv.style.left = (event.pageX - dragObject.offsetHeight/8) + "px";
        actionTabDiv.style.top = (event.pageY - dragObject.offsetHeight*11/16) + "px";
    }
}

function clActionBuild(_position,_size)
{
    this.m_name = "build";
    this.m_size = _size;
    this.m_action = "clActionBuild.sf_action(" + _position +")";
    clActionBuild.sf_action = function action(_position)
    {
        var buildCastle = new clChooseBuilding('castle',_position,256);
        var buildHouse = new clChooseBuilding('house',_position,128);
        g_Game.m_actionTab.f_show(new Array(buildCastle,buildHouse),-1); //-1 means same position
    }
}

function clChooseBuilding(_name, _position, _size)
{
    this.m_name = _name;
    this.m_size = _size;
    this.m_action = "clChooseBuilding.sf_action('" + _name + "'," + _position +")";
    clChooseBuilding.sf_action = function action(_name,_position)
    {
        g_Game.m_actionTab.f_close();
        g_Game.m_actionTab.f_createDragObject(_name);
    }
}


