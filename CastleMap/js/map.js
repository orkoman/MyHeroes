function clMapDataObject()
{
    this.f_init = init;

    function init(_mapSize) {
        this.m_position = this.m_position * 1;
        //create
        //alert(this.m_size);
        this.m_position2 = position_toXY(this.m_position, _mapSize,-this.m_size*32, -this.m_size*16 + this.m_size * 48);

        var n = this.m_position%_mapSize;
        var m = (this.m_position - n)/_mapSize;
        this.m_z = 1000 + m*_mapSize - n + _mapSize;
        //alert(this.m_name + ' ' + this.m_z);
        this.m_id = this.m_name + this.m_castlebuildings_id;
    }
}

function clBuilding(_dataArr,_mapSize)
{
    this.m_name = _dataArr[0];
    this.m_size = _dataArr[1];
    this.m_level = _dataArr[2];
    this.m_position = _dataArr[3];
    this.m_castlebuildings_id = _dataArr[4];
//--v2
    this.m_status = _dataArr[5];
    this.m_lastUpdate = _dataArr[6];

    if (this.m_status == 0)
    {
        this.f_createDiv = createEmpty;
    }
    else
    {
        this.f_createDiv = createDiv;
    }

    this.f_createEmpty = createEmpty;
    this.f_doSomething = doSomething;

    this.f_init(_mapSize);

    function createDiv()
    {
        return ("<div id = '" + this.m_id + "' class='" + this.m_name +"' style = 'left:" + this.m_position2.m_x + "px;top:" + this.m_position2.m_y + "px;z-index:" + this.m_z + ";'>" + this.m_name + ' level ' + this.m_level +"</div>");
    }

    function createEmpty()
    {
        var name = 'building' + this.m_size + 'x' + this.m_size;
        var divDate = "<div id='" + this.m_id + "_d' class='dateTime'></div>";
        return ("<div id = '" + this.m_id + "' class='" + name +"' style = 'left:" + this.m_position2.m_x + "px;top:" + this.m_position2.m_y + "px;z-index:" + this.m_z + ";'>" + divDate +"</div>");
    }

    function doSomething(t_sec)
    {
        var dateDiv = document.getElementById(this.m_id + "_d");
        if (dateDiv != null) {
            var time = this.m_lastUpdate - Math.floor(Date.now() / 1000);
            if (time >= 0) {
                dateDiv.innerHTML = "" + time;
            }
            else
            {
                this.m_status = 1;
                //TODO building complete
            }
        }
    }
}

function clNature(_dataArr,_mapSize)
{
    this.m_name = _dataArr[0];
    this.m_size = _dataArr[1];
    this.m_position = _dataArr[2];
    this.m_castlebuildings_id = _dataArr[3];

    this.f_createDiv = createDiv;

    this.f_init(_mapSize);

    function createDiv()
    {
        return ("<div id = '" + this.m_id + "' class='" + this.m_name +"' style = 'left:" + this.m_position2.m_x + "px;top:" + this.m_position2.m_y + "px;z-index:" + this.m_z + ";'>" + this.m_name + "</div>");
    }
}

clBuilding.prototype = new clMapDataObject();
clNature.prototype = new clMapDataObject();


function clMap(_id, _size, _buildings,_nature)
{
	this.m_mapDiv = document.getElementById(_id);
	this.m_size = _size;

	this.m_buildings = decodeData(_buildings,clBuilding,_size);
    this.m_nature = decodeData(_nature,clNature,_size);
    this.m_people = 0;
	this.m_colisionMap = 0;
	
	this.f_init = init;
    this.f_doSomething = doSomething;
    this.f_fillMap = fillMap;
    this.f_checkPlace = checkPlace;
    this.f_addBuilding = addBuilding;
    this.f_showBuildingsAndNature = showBuildingsAndNature;
	
	this.f_init();
	
	function init()
	{
        //create collision
		this.m_colisionMap = new Array(this.m_size*this.m_size);
		var count = this.m_size*this.m_size;
		for(var n = 0; n < count;n++)
		{
			this.m_colisionMap[n] = 0; //empty id
		}

		var temp = "";
        //create fields
        var count = this.m_size*this.m_size;
        for(var position = 0; position < count;position++)
        {
            var pos2 = position_toXY(position,this.m_size,-32,0);
            var z = 100 + position;
            var id = position;
            temp += "<div id = 'f_" + id + "' class='field' style = 'left:" + pos2.m_x + "px;top:" + pos2.m_y + "px;z-index:" + z + ";'></div>";
        }

        //create buildings
        temp += "<div id='buildings'>";
        var count = this.m_buildings.length;
        for(var i = 0; i < count;i++)
        {
            this.f_fillMap(this.m_buildings[i]);
            temp += this.m_buildings[i].f_createDiv();
        }
        temp += "</div>";

        //create nature
        temp += "<div id='nature'>";
        var count = this.m_nature.length;
        for(var i = 0; i < count;i++)
        {
            this.f_fillMap(this.m_nature[i]);
            temp += this.m_nature[i].f_createDiv();
        }
        temp += "</div>";

        // create people div
        var count = this.m_size;
        for(var n = 0; n < count;n++)
        {
            var z = 2000;
            temp += "<div id = 'm_" + n + "' class='man' style = 'z-index:" + z + ";'></div>";
        }


		//alert(temp);
		this.m_mapDiv.innerHTML = temp;

        //create people obj
        this.m_people = new Array(count);
        for(var n = 0; n < count;n++)
        {
            this.m_people[n] = new clMan('m_' + n,this);
        }
	}

    function fillMap(_building)
    {
        // fill map
        for(var x1 = 0; x1 < _building.m_size;x1++)
        {
            for(var y1 = 0; y1 < _building.m_size;y1++)
            {
                var newPosition = _building.m_position*1 + y1*this.m_size + x1;
                this.m_colisionMap[newPosition] = _building.m_id;
            }
        }
    }

    function checkPlace(_position, _size)
    {
        var maxSize = this.m_size*this.m_size;
        var x = _position%this.m_size;
        if (x + _size > this.m_size ||
            _position + (_size-1)*this.m_size >= maxSize)
        {
            //alert(_position);
            return false;
        }
        _size ++;
        for(var x1 = -1; x1 < _size;x1++)
        {
            for(var y1 = -1; y1 < _size;y1++)
            {
                var newPosition = _position + y1*this.m_size + x1;
                if (x + x1 >= 0 && x + x1 < this.m_size && newPosition >= 0 && newPosition < maxSize) {
                    if (this.m_colisionMap[newPosition] != 0) {
                        //alert((x + x1) + ' ' + newPosition);
                        return false;
                    }
                }
            }
        }
        return true;
    }

    function doSomething(t_milli)
    {
        var t_sec = t_milli/1000.0;
        var count = this.m_people.length;
        for(var n = 0; n < count;n++)
        {
            this.m_people[n].f_doSomething(t_sec);
        }

        count = this.m_buildings.length;
        for(var n = 0; n < count;n++)
        {
            this.m_buildings[n].f_doSomething(t_sec);
        }
    }

    this.f_listener =
        function listener(_result) {
            var building = decodeData(_result,clBuilding,this.m_size)[0];
            this.m_buildings[this.m_buildings.length] = building;
            this.f_fillMap(building);
            document.getElementById("buildings").innerHTML += building.f_createEmpty();
        }

    function addBuilding(_buildingId,_position,_size)
    {
        if (this.f_checkPlace(_position,_size) == true) {
            g_Game.m_ajaxHelper.f_sendRequest(this, "2&i=" + _buildingId + "&p=" + _position);
        }
        else
        {
            alert("cant build here!");
            return true;
        }
        return true;
    }

    function showBuildingsAndNature(_show)
    {
        var buildingsDiv = document.getElementById("buildings");
        var natureDiv = document.getElementById("nature");
        var fieldStyle = clGame.sf_getGraph("grass.png");
        if (_show)
        {
            buildingsDiv.style.visibility = "visible";
            natureDiv.style.visibility = "visible";
        }
        else
        {
            buildingsDiv.style.visibility = "hidden";
            natureDiv.style.visibility = "hidden";
            fieldStyle = clGame.sf_getGraph("grass_hover.png");
        }

        var count = this.m_size*this.m_size;
        for(var n = 0; n < count;n++)
        {
            if (this.m_colisionMap[n] != 0) {
                var field = document.getElementById("f_" + n);
                field.style.backgroundImage = fieldStyle;
            }
        }
    }

}









