<?php
/**
 * Created by PhpStorm.
 * User: Z002Y7UA
 * Date: 27.02.2015
 * Time: 12:37
 */

include_once 'backend/mainIncludes.php';
include_once MAINDIR . "/backend/classes/clServer.php";

$result = true;
$result &= testNotIntersect(0,2,3,4,20);
$result &= testNotIntersect(3,4,0,2,20);
$result &= !testNotIntersect(0,2,2,4,20);
$result &= testNotIntersect(0,4,103,2,20);
$result &= !testNotIntersect(0,4,83,2,20);
$result &= testNotIntersect(0,4,85,5,20);

$result &= testNotIntersect(0,4,77,3,10);
$result &= testNotIntersect(0,4,55,3,10);
$result &= testNotIntersect(0,4,26,3,10);

$result &= clUtils::inMap(new clPosition(7,7),3,10);
$result &= clUtils::inMap(new clPosition(5,5),3,10);
$result &= clUtils::inMap(new clPosition(6,2),3,10);

if ($result)
{
    print "OK";
}
else
{
    print "Not OK";
}
print "<br>";
$_SESSION["id"] = 3;
$test = clServer::getBuildings();
print $test;

print "<br>";
$test = clGameData::getAllBuildingsToBuild();
print $test;
print "<br>-----------date--------------<br>";
$date = new DateTime();
$timeSecond = strtotime('2015-01-01 00:00:00');
$differenceInSeconds = $date->getTimestamp() - $timeSecond;
$diff = $differenceInSeconds*10000;
$s = $differenceInSeconds%60;
$differenceInSeconds = ($differenceInSeconds - $s)/60;
$mi = $differenceInSeconds%60;
$differenceInSeconds = ($differenceInSeconds - $mi)/60;
$h = $differenceInSeconds%24;
$differenceInSeconds = ($differenceInSeconds - $h)/24;
$d = $differenceInSeconds;
print "$d d  $h h  $mi m  $s s    =    $diff s";

/*print "<br>";
$test = clGameData::getBuildingDataByName('castle')->requestDataFull();
print $test;*/


function testNotIntersect($_pos,$_size,$_pos1,$_size1,$_mapSize) //todo put to utils
{
    $p2mainPos = clUtils::transform($_pos,$_mapSize);
    //print_r($p2mainPos);
    return (clUtils::buildingsNotIntersect($p2mainPos,$_size,$_pos1,$_size1,$_mapSize));
}



?>