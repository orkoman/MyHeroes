<?php
/**
 * Created by PhpStorm.
 * User: z002y7ua
 * Date: 13.03.2015
 * Time: 13:52
 */

include_once "dbConnection.php";
include_once "clAMapObject.php";

class clBuilding extends clAMapObject{
    public static $s_id = 0;
    public function clBuilding($_name,$_size,$_time,$_peopleMax,$_startHp)
    {
        self::$s_id ++;
        parent::clAMapObject(self::$s_id,$_name,$_size);
        $this->time = $_time;
        $this->peopleMax = $_peopleMax;
        $this->startHp = $_startHp;


        $this->lastString = "";
    }

    public function requestDataFull()
    {
        return ($this->id.'_'.$this->name.'_'.$this->size);
    }

    public function calculateTime($_level)
    {
        return min(floor(pow(2,$_level - 1)*$this->time),$_level*24*$this->time)*60;
    }

    public function createNewBuilding($_position,$_mapSize,$_status)
    {
        if (self::checkBuild($_position,$this->size,$_mapSize)) {

            $castle_id = clGameFactory::selectCastleID(); //TODO must be moved from gameFactory
            $building_id = $this->id;
            $level = 1;
            $hp = $this->startHp;
            $lastUpdate = clUtils::calculateDate($_status) + $this->calculateTime(1);

            if (dbConnection::connect()) {
                $sql = "INSERT INTO castlebuildings (castle_id, building_id,level,position,hitpoints,lastUpdate,status)
                              VALUES ($castle_id,$building_id,$level,$_position,$hp,$lastUpdate,$_status)";
                if (dbConnection::$connectionID->query($sql) === TRUE) {
                    //TODO very bad wrote
                    $this->lastString = $this->requestData().'_'.$level.'_'.$_position.'_'.dbConnection::$connectionID->insert_id.'_'.$_status.'_'.$lastUpdate.'*';
                    return true;
                } else {
                    $_SESSION["lastError"] = $_SESSION["lastError"]."Error in database while insert building $sql";
                    return false;
                }
            }
        }
        $_SESSION["lastError"] = $_SESSION["lastError"].'Couldnot createNewBuilding '.$this->name.' '.$_position.' '.$this->size.' '.$_mapSize;
        return false;
    }
}
