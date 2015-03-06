//var g_Map = new clMap('map',20);

function clResourceTab(_id,_resources)
{
	//this.puffer = 2;
	this.m_resourceDiv = document.getElementById(_id);
	this.m_size = 96;
    this.m_resources = _resources;

	this.f_create = create;

	this.f_create();

	function create()
	{
		var temp = "";
        //create resources
        var resourcesArr = this.m_resources.split('*');
        var count = resourcesArr.length;

        for(var i = 0; i < count;i++)
        {
            if (resourcesArr[i].length > 0)
            {
                var resourcesPropsArr = resourcesArr[i].split('_');

                var name = resourcesPropsArr[0];
                var amount = resourcesPropsArr[1];
                var profit = resourcesPropsArr[2];

                var x = i*this.m_size;
                var y = 0;
                var z = 0;
                var id = name;

                var divIcon = "<div class='resourceIcon' style=\"background-image:url('../img/icons/" + name + ".png');\"></div>";
                var divText = "<div class='resourceText'>" + amount + '(' + profit + ")</div>";
                temp += "<div id = '" + id + "' style = 'left:" + x + "px;top:" + y + "px;'>" + divIcon + divText + "</div>";

            }
        }
		//alert(temp);
		this.m_resourceDiv.innerHTML = temp;
	}
}

function clActionTab(_id)
{
    this.m_actionDiv = document.getElementById(_id);
    this.m_dragObject = 0;

    this.f_createDragObject =
    function createDragObject(_name)
    {
        this.m_actionDiv.innerHTML = "<div id = 'drag' class ='" + _name + "' ></div>";
        this.m_dragObject = document.getElementById('drag');
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
            x += 5 + _actions[n].m_size;
            if (size < _actions[n].m_size)
            {
                size = _actions[n].m_size;
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









