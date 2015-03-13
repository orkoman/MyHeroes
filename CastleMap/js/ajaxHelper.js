function clAjaxHelper(_mainUri)
{
    this.m_mainUri = _mainUri;

    this.f_sendRequest =
    function sendRequest(_listenerObj,_value)
    {
        //alert(_listenerObj);;
        var xmlhttp = new XMLHttpRequest();
        xmlhttp.onreadystatechange = listener;
        xmlhttp.open("GET", _mainUri + "/backend/ajaxServer.php?t=" + _value, true);
        xmlhttp.send();

        function listener()
        {
            if (xmlhttp.readyState == 4 &&
                xmlhttp.status == 200) {
                var len = parseInt(xmlhttp.responseText.substr(0,4),16);
                var response = xmlhttp.responseText.substr(4);
                //alert(len + ' ' + response);
                if (response.length == len) {
                    //alert(_listenerObj.f_listener);
                    _listenerObj.f_listener(response);
                }
                else
                {
                    alert("Error: " + len + ' ' + response);
                }
            }
        }
    }
}