function clGame(mainUri,_size,_buildings,nature,resources) {

    this.m_size = _size;
    this.m_cashedBuildings = 0;

    this.f_init = init;
    this.f_mainLoop = mainLoop;
//TODO preload images
    clGame.sf_getGraph = function (_localPath) {
        return "url('img/" + _localPath + "')";
    }

    this.f_init();

    function init()
    {
        this.m_ajaxHelper = new clAjaxHelper(mainUri);
        //this.m_ajaxHelper.f_sendRequest(this.f_listener,"test1");
        //this.m_ajaxHelper.f_sendRequest(this.f_listener,"test2");


        this.m_objlist = new Array();

        this.m_map = new clMap('map',this.m_size,_buildings,nature);
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

    var isoY = Math.floor((x / 32 + y / 16) /2) - g_Game.m_map.m_size/2;
    var isoX = Math.floor((y / 16 - x / 32) /2) + g_Game.m_map.m_size/2;

    var position = isoY*g_Game.m_map.m_size + isoX;

    //alert(position);
    var dragObject = g_Game.m_actionTab.m_dragObject;
    if (dragObject != 0)
    {
        //alert(position + ' ' + dragObject.m_size);
        position -= (dragObject.m_size - 1);
        if (g_Game.m_map.f_addBuilding(dragObject.m_buildingId,position,dragObject.m_size)) {
            g_Game.m_actionTab.f_removeDragObject();
            g_Game.m_map.f_showBuildingsAndNature(true);
        }
    }
    else {
        var p2Point = new clPoint2(event.pageX, event.pageY);

        if (g_Game.m_map.m_colisionMap[position] != 0) {
            //alert(g_Map.m_colisionMap[position]);
            //var element = document.getElementById(g_Game.m_map.m_colisionMap[position]);
            //element.style.backgroundImage = clGame.sf_getGraph("grass_hover.png");
            //TODO get from server
            g_Game.m_actionTab.f_show(new Array(new clActionSetPeople(),new clActionCancel()), p2Point);
        }
        else {
            // get grass
            //var element = document.getElementById('f_' + position);
            //element.style.backgroundImage = "url('" + clGame.imgLocalPath + "/grass_hover.png')";

            g_Game.m_actionTab.f_show(new Array(new clActionBuild(), new clActionCancel()), p2Point);
        }
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
        actionTabDiv.style.left = (event.pageX) + "px";
        actionTabDiv.style.top = (event.pageY - dragObject.m_dragDiv.offsetHeight*3/4) + "px";
    }
}






