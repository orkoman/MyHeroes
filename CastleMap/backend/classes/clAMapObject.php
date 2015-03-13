<?php
/**
 * Created by PhpStorm.
 * User: z002y7ua
 * Date: 13.03.2015
 * Time: 13:52
 */

include_once "dbConnection.php";

class clAMapObject {
    public function clAMapObject($_id,$_name,$_size)
    {
        $this->id = $_id;
        $this->name = $_name;
        $this->size = $_size;
    }

    public function requestData()
    {
        return ($this->name.'_'.$this->size);
    }

    protected static function checkBuild($_pos,$_size,$_mapSize)
    {
        //print " $_pos,$_size,$_mapSize !!";
        $p2mainPos = clUtils::transform($_pos,$_mapSize);
        if (clUtils::inMap($p2mainPos,$_size,$_mapSize))
        {
            $castle_id = clGameFactory::selectCastleID();
            if ($castle_id != -1) {
                $sql = "SELECT building_id,
                           position
                    FROM castlebuildings
                    WHERE castlebuildings.castle_id = '$castle_id'";

                $result = dbConnection::query($sql);
                if ($result->num_rows > 0) {
                    while ($row = $result->fetch_assoc()) {
                        $building_id = $row['building_id'];
                        $size = clGameData::getBuildingDataByID($building_id)->size;
                        $pos = $row['position'];

                        if (clUtils::buildingsNotIntersect($p2mainPos, $_size, $pos, $size, $_mapSize)) {
                            return true;
                        }
                    }
                }
                return true; //no other buildings
            }
        }
        print "checkBuild ERROR";
        return false; //error
    }
}
