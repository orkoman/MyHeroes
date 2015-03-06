<?php
/**
 * Created by PhpStorm.
 * User: z002y7ua
 * Date: 03.03.2015
 * Time: 12:43
 */

include_once "dbConnection.php";
include_once "gameFactory.php";

class clServer {

    public static function getBuildings()
    {
        $buildingsResult = "";
        $castle_id = gameFactory::selectCastleID();
        if ($castle_id != -1) {
            if (dbConnection::connect()) {
                $sql = "SELECT buildings.name as name,
                           buildings.size as size,
                           castlebuildings.level as level,
                           castlebuildings.position as position,
                           castlebuildings.id as cb_id
                    FROM castlebuildings, buildings
                    WHERE castlebuildings.castle_id = '$castle_id'
                    AND castlebuildings.building_id = buildings.id";


                $result = dbConnection::$connectionID->query($sql);
                //print_r($result);
                if ($result->num_rows > 0) {
                    // output data of each row
                    while ($row = $result->fetch_assoc()) {
                        $name = $row['name'];
                        $size = $row['size'];
                        $level = $row['level'];
                        $position = $row['position'];
                        $castlebuildings_id = $row['cb_id'];

                        $buildingsResult = $buildingsResult . "${name}_${size}_${level}_${position}_${castlebuildings_id}*";
                    }
                }
            }
            //print "$buildingsResult";
        }
        return $buildingsResult;
    }

    public static function getNature()
    {
        $natureResult = "";
        $castle_id = gameFactory::selectCastleID();
        if ($castle_id != -1) {
            if (dbConnection::connect()) {
                $sql = "SELECT nature.name as name,
                           nature.size as size,
                           castlenature.position as position,
                           castlenature.id as cb_id
                    FROM castlenature, nature
                    WHERE castlenature.castle_id = '$castle_id'
                    AND castlenature.nature_id = nature.id";


                $result = dbConnection::$connectionID->query($sql);
                //print_r($result);
                if ($result->num_rows > 0) {
                    // output data of each row
                    while ($row = $result->fetch_assoc()) {
                        $name = $row['name'];
                        $size = $row['size'];
                        $position = $row['position'];
                        $castlenature_id = $row['cb_id'];

                        $natureResult = $natureResult . "${name}_${size}_${position}_${castlenature_id}*";
                    }
                }
            }
        }
        //print "$natureResult";
        return $natureResult;
    }

    public static function getResources()
    {
        $resResult = "";
        $castle_id = gameFactory::selectCastleID();
        if ($castle_id != -1) {
            if (dbConnection::connect()) {
                $sql = "SELECT resources.name as name,
                           castleresources.amount as amount,
                           castleresources.profit as profit
                    FROM castleresources, resources
                    WHERE castleresources.castle_id = '$castle_id'
                    AND castleresources.resource_id = resources.id";


                $result = dbConnection::$connectionID->query($sql);
                //print_r($result);
                if ($result->num_rows > 0) {
                    // output data of each row
                    while ($row = $result->fetch_assoc()) {
                        $name = $row['name'];
                        $amount = $row['amount'];
                        $profit = $row['profit'];

                        $resResult = $resResult . "${name}_${amount}_${profit}*";
                    }
                }
            }
            //print "$buildingsResult";
        }
        return $resResult;
    }
}


?>