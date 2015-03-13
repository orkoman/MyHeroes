<?php
/**
 * Created by PhpStorm.
 * User: z002y7ua
 * Date: 12.03.2015
 * Time: 16:03
 */

include_once "clBuilding.php";
include_once "clNature.php";
include_once "clResource.php";


class clGameData {

    private static $startMapSize = 10;
    private static $startMaxResources = 1000;

    private static $buildings = 0;
    public static $nature = 0;
    public static $resource = 0;

    public static function getBuildingDataByID($_id)
    {
        if (self::$buildings == 0)
        {
            self::createBuildings();
        }
        //print_r(self::$buildings);
        return self::$buildings[$_id];
    }

    public static function getAllBuildingsToBuild()
    {
        $result = "";
        if (self::$buildings == 0)
        {
            self::createBuildings();
        }
        foreach(self::$buildings as $key => $building)
        {
            if ($key != 1) {
                $result = $result . $building->requestDataFull() . "*";
            }
        }
        return $result;
    }

    public static function createBuildings()
    {
        self::$buildings = array();
        self::$buildings[1] = new clBuilding('castle',4,60,0,1000);
        self::$buildings[2] = new clBuilding('house',2,10,0,200);
        self::$buildings[3] = new clBuilding('store',3,40,0,600);
        self::$buildings[4] = new clBuilding('stonecutter',2,30,0,400);
        self::$buildings[5] = new clBuilding('woodcutter',2,30,0,400);
    }

    public static function getNatureDataByID($_id)
    {
        if (self::$nature == 0)
        {
            self::createNature();
        }
        //print_r(self::$nature);
        return self::$nature[$_id];
    }

    public static function getRandomNature()
    {
        if (self::$nature == 0)
        {
            self::createNature();
        }
        //print_r(self::$nature);
        $rand = rand(1,count(self::$nature));
        return self::$nature[$rand];
    }

    public static function createNature()
    {
        self::$nature = array();
        self::$nature[1] = new clNature('wood',3);
        self::$nature[2] = new clNature('stone',3);
    }

    public static function getResourceByID($_id)
    {
        if (self::$resource == 0)
        {
            self::createResource();
        }
        //print_r(self::$resource);
        return self::$resource[$_id];
    }

    public static function createResources()
    {
        if (self::$resource == 0)
        {
            self::createResource();
        }

        $funcResult = true;
        $count = count(self::$resource);
        for($n = 1; $n <= $count;$n++)
        {
            $resource = clGameData::getResourceByID($n);
            $funcResult &= $resource->createResource(self::$startMaxResources);
        }
        if ($funcResult)
        {
            return true;
        }
        $_SESSION["lastError"] = $_SESSION["lastError"]."Couldnot create resources!";
        return false;
    }

    private static function createResource()
    {
        self::$resource = array();
        self::$resource[1] = new clResource('people',50);
        self::$resource[2] = new clResource('gold',500);
        self::$resource[3] = new clResource('lumber',100);
        self::$resource[4] = new clResource('stone',0);
    }

    public static function getStartMapSize()
    {
        return self::$startMapSize;
    }

    public static function createNatureAll($_castlePosition,$_castleSize,$_mapSize)
    {
        //TODO currently only one will be created
        $p2castlePos = clUtils::transform($_castlePosition,$_mapSize);
        $nature = self::getRandomNature();
        //print "$_castlePosition, $_castleSize, $nature->size";
        //$position = 0;
        $index = 0;
        do
        {
            $position = rand(0, $_mapSize * $_mapSize - 1);
            $p2Position = clUtils::transform($position,$_mapSize);

            print "      !";
            if ($index > 100)
            {
                break;
            }
            $index++;

        }while(!clUtils::buildingsNotIntersect($p2castlePos, $_castleSize, $position, $nature->size, $_mapSize) ||
               !clUtils::inMap($p2Position,$nature->size,$_mapSize));

        if ($nature->createNature($position,$_mapSize))
        {
            return true;
        }
        $_SESSION["lastError"] = $_SESSION["lastError"]."Couldnot create nature!";
        return false;
    }
}