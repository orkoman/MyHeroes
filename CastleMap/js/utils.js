/*function stringToDateTime(_str)
{
    var year = _str.substr(0,4);
    var month = _str.substr(5,2);
    var day = _str.substr(8,2);
    var hour = _str.substr(11,2);
    var minute = _str.substr(13,2);
    var second = _str.substr(15,2);
    return new Date(year,month,day,hour,minute,second);
}*/

function clPoint2(_x,_y)
{
    this.m_x = _x;
    this.m_y = _y;
}

function position_toXY(_position,_size,_object_size_x,_object_size_y)
{
    var n = _position%_size;
    var m = (_position - n)/_size;

    return new clPoint2(_size*32 + m*32 - n*32 + _object_size_x,
                         n*16 + m*16 - _object_size_y);
}

function decodeData(_data, _objClass,_extraArg)
{
    //alert(_data);
    var dataArr = _data.split('*');
    var count = dataArr.length - 1;
    var dataArrResult = new Array();
    for(var i = 0; i < count;i++) {
        //alert(dataArr[i] + " " + dataArr[i].length );
        //if (dataArr[i].length > 0) {
            var dataPropsArr = dataArr[i].split('_');
            dataArrResult[i] = new _objClass(dataPropsArr,_extraArg);
        //}
    }
    return dataArrResult;
}

//---------------------------------------------------------
function clTimer(_loopFunction, _milliseconds)
{
    this.m_intervalID = 0;
    this.m_loopFunction = _loopFunction;
    this.m_ms = _milliseconds;

    this.f_getDeltaTime = getDeltaTime;
    this.f_start = start;
    this.f_stop = stop;

    function getDeltaTime()
    {
        var tempTime = new Date();
        tempTime = tempTime.getTime();
        var deltaTime = tempTime - this.m_lastTime;
        this.m_lastTime = tempTime;
        return deltaTime;
    }

    function start()
    {
        if (this.m_intervalID == 0) {
            this.m_lastTime = new Date().getTime();

            this.m_intervalID = setInterval(this.m_loopFunction, this.m_ms);
            //alert(this.m_intervalID + ' ' + _loopFunction);
        }
    }

    function stop()
    {
        if (this.m_intervalID != 0) {
            clearInterval(this.m_intervalID);
            this.m_intervalID = 0;
        }
    }
}

//-------------------------------------------------------------
function debug(_condition,msg)
{
    if (_condition)
    {
        alert(msg);
    }
}

function getPath(_map,_position1, _position2)
{
    debug(_position1 < 0 && _position1 > _map.m_size*_map.m_size - 1,'position1 must be 0-399');
    debug(_position2 < 0 && _position2 > _map.m_size*_map.m_size - 1,'position2 must be 0-399');
    debug(_position1 == _position2,'position1 must not be equal position2');

    //copy collisionmap
    var tempCollisionMap = new Array(_map.m_size*_map.m_size);
    var count = _map.m_size*_map.m_size;
    for(var n = 0; n < count;n++)
    {
        tempCollisionMap[n] = _map.m_colisionMap[n];
    }
    tempCollisionMap[_position1] = 1;

    var tempPath = new Array();
    tempPath[0] = new Array();
    tempPath[0][0] = _position1;

    var path = oneRound(tempPath,tempCollisionMap,_position2,_map.m_size)
    return path;
}

function oneRound(_path,_collisionsMap,_position2,_size)
{
    var newPath = new Array();
    for(var n = 0; n < _path.length;n++) {
        var position =_path[n][_path[n].length - 1];

        if (position == _position2) {
            return _path[n];
        }

        /*var tempPath = new Array(8);
         for (var n = 0; n < 8; n++) {
         tempPath = new Array();
         }*/

        var x = position % _size;
        var notLeft = (x != 0);
        var notRight = (x != _size - 1);

        var notTop = (position > _size - 1);
        var notBottom = (position < _size * (_size - 1));

        oneStep(newPath,_path[n], _collisionsMap, notLeft, position - 1);
        oneStep(newPath,_path[n], _collisionsMap, notRight, position + 1);
        oneStep(newPath,_path[n], _collisionsMap, notTop, position - _size);
        oneStep(newPath,_path[n], _collisionsMap, notBottom, position + _size);

        oneStep(newPath,_path[n], _collisionsMap, notLeft && notTop, position - 1 - _size);
        oneStep(newPath,_path[n], _collisionsMap, notLeft && notBottom, position - 1 + _size);
        oneStep(newPath,_path[n], _collisionsMap, notRight && notTop, position + 1 - _size);
        oneStep(newPath,_path[n], _collisionsMap, notRight && notBottom, position + 1 + _size);

    }
    if (newPath.length == 0)
    {
        if (_collisionsMap[_path[0][0]] != 0)
        {
            return -2; //die
        }
        else {
            alert('no possible path ' + _path[0][0] + ' ' + _position2);
            return 0;
        }
    }

    return oneRound(newPath,_collisionsMap,_position2,_size);
}

function oneStep(_newPath,_path,_collisionsMap,_condition,_move)
{
    //alert(_move + ' ' + _condition + ' ' + (_collisionsMap[_move] == 0));
    if (_condition && _collisionsMap[_move] == 0) {
        _collisionsMap[_move] = 1;
        //_path[_path.length] = _move;
        var tempArr = _path.slice(0);
        tempArr[tempArr.length] = _move;
        _newPath[_newPath.length] = tempArr;
    }
}







