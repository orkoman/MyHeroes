function clMapDataObject()
{
    this.f_init = init;

    function init(_size) {
        this.m_position = this.m_position * 1;
        //create
        this.m_position2 = position_toXY(this.m_position, _size,0, this.m_size * 48);

        this.m_z = 1000 + this.m_position;
        this.m_id = this.m_name + this.m_castlebuildings_id;
    }
}

function clBuilding(_dataArr,_size)
{
    this.m_name = _dataArr[0];
    this.m_size = _dataArr[1];
    this.m_level = _dataArr[2];
    this.m_position = _dataArr[3];
    this.m_castlebuildings_id = _dataArr[4];

    this.f_createDiv = createDiv;

    this.f_init(_size);

    function createDiv()
    {
        return ("<div id = '" + this.m_id + "' class='" + this.m_name +"' style = 'left:" + this.m_position2.m_x + "px;top:" + this.m_position2.m_y + "px;z-index:" + this.m_z + ";'>" + this.m_name + ' level ' + this.m_level +"</div>");
    }
}

function clNature(_dataArr,_size)
{
    this.m_name = _dataArr[0];
    this.m_size = _dataArr[1];
    this.m_position = _dataArr[2];
    this.m_castlebuildings_id = _dataArr[3];

    this.f_createDiv = createDiv;

    this.f_init(_size);

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
            var pos2 = position_toXY(position,this.m_size,0,16);
            var z = 100 + position;
            var id = position;
            temp += "<div id = 'f_" + id + "' class='field' style = 'left:" + pos2.m_x + "px;top:" + pos2.m_y + "px;z-index:" + z + ";'></div>";
        }

        //create buildings
        var count = this.m_buildings.length;
        for(var i = 0; i < count;i++)
        {
            this.f_fillMap(this.m_buildings[i]);
            temp += this.m_buildings[i].f_createDiv();
        }

        //create nature
        var count = this.m_nature.length;
        for(var i = 0; i < count;i++)
        {
            this.f_fillMap(this.m_nature[i]);
            temp += this.m_nature[i].f_createDiv();
        }

        // create people div
        var count = 20;
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
            this.m_people[n] = new clMan('m_' + n,this.m_size*this.m_size/2 + this.m_size/2,this);
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
                //alert(newPosition);
                this.m_colisionMap[newPosition] = _building.m_id;
            }
        }
    }

    function doSomething(t_milli)
    {
        var count = this.m_people.length;
        for(var n = 0; n < count;n++)
        {
            this.m_people[n].f_doSomething(t_milli/1000.0);
        }
    }


}









