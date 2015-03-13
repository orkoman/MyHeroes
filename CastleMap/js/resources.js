function clResource(_dataArr,_extraArg)
{
    this.m_name = _dataArr[0];
    this.m_amount = _dataArr[1];
    this.m_profit = _dataArr[2];
    this.m_maxAmount = _dataArr[3];

    this.f_createDiv = createDiv;

    function createDiv(_left)
    {
        var style = clGame.sf_getGraph("icons/" + this.m_name +".png");
        var divIcon = "<div class='resourceIcon' style=\"background-image:" + style + ";\"></div>";
        var divText = "<div class='resourceText'>" + this.m_amount + '/' + this.m_maxAmount + '(' + this.m_profit + ")</div>";
        return ("<div id = '" + this.m_name + "' style = 'left:" + _left + "px;top:" + 0 + "px;'>" + divIcon + divText + "</div>");
    }
}

function clResourceTab(_id,_resources)
{
	//this.puffer = 2;
	this.m_resourceDiv = document.getElementById(_id);
	this.m_size = 128;
    this.m_resources = decodeData(_resources,clResource,0); //0 - no _extraArg

	this.f_create = create;

	this.f_create();

	function create()
	{
		var temp = "";
        //create resources
        var count = this.m_resources.length;
        for(var n = 0; n < count;n++)
        {
            var x = n*this.m_size;
            temp += this.m_resources[n].f_createDiv(x);
        }
		//alert(temp);
		this.m_resourceDiv.innerHTML = temp;
	}
}












