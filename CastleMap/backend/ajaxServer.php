<?php
/**
 * Created by PhpStorm.
 * User: z002y7ua
 * Date: 09.03.2015
 * Time: 18:03
 */

include_once "classes/clServer.php";

session_start();

$type = $_GET["t"];

switch ($type) //return buildings that can be build
{
    case 1: { //return buildings that can be build
        $player_id = $_SESSION["id"];

        if (dbConnection::connect()) {
            $result = clGameData::getAllBuildingsToBuild();
            clServer::safeReturn($result);
        }
    }break;
    case 2: { //build new building
        $position = $_GET["p"];
        $buildingId = $_GET["i"];
        $building = clGameData::getBuildingDataByID($buildingId);
        $mapSize = clGameFactory::selectMapSize();

        if ($building->createNewBuilding($position,$mapSize,0)) //0 - status build normal
        {
            clServer::safeReturn($building->lastString);
            return;
        }
        else
        {
            clServer::safeReturn("ERROR1 ".$position.' '.$building->size.' '.$mapSize.' '.$_SESSION["lastError"]);
            $_SESSION["lastError"] = "";
        }

        /*if (clGameFactory::checkBuild($position,$building->requestSize(),$mapSize))
        {
            if (clGameFactory::createNewBuilding($buildingId,1,$position,$building->requestHp()))
            {
                clServer::safeReturn($position."_".$building->requestData());
                return;
            }
            else
            {
                clServer::safeReturn("ERROR2");
            }
        }*/

    }break;
    default: {
        print "ERROR";
    }
}

?>