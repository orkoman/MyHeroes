<?php
/**
 * Created by PhpStorm.
 * User: Z002Y7UA
 * Date: 27.02.2015
 * Time: 15:06
 */

include_once "dbConnection.php";

class gameFactory {

    public static $cashedCastleID = 0;

    public static function createCastle()
    {
        $player_id = $_SESSION["id"];
        if (dbConnection::connect()) {
            $sql = "INSERT INTO castles (name, player_id)
                              VALUES ('noname','$player_id')";

            if (dbConnection::$connectionID->query($sql) === TRUE) {
                $castle_id = dbConnection::$connectionID->insert_id;
                self::$cashedCastleID = $castle_id;

                $sql = "UPDATE users set current_castle_id = '$castle_id' where id = '$player_id'";
                if (dbConnection::$connectionID->query($sql) === TRUE) {
                    $result = gameFactory::createBuilding($castle_id, 1, 1, 16);
                    $result &= gameFactory::createResources($castle_id);
                    $result &= gameFactory::createNatureAll($castle_id);
                    return $result;
                }
            } else {
                $_SESSION["lastError"] = "Error in database while insert castle";

            }
        }
        return false;
    }

    public static function createBuilding($castle_id,$building_id,$level,$position)
    {
        if (dbConnection::connect()) {
            $sql = "INSERT INTO castlebuildings (castle_id, building_id,level,position)
                              VALUES ($castle_id,$building_id,$level,$position)";
            if (dbConnection::$connectionID->query($sql) === TRUE) {
                return true;
            } else {
                $_SESSION["lastError"] = "Error in database while insert building $castle_id,$building_id,$level,$position";
                return false;
            }
        }
    }

    public static function createNatureAll($castle_id)
    {
        //TODO currently only one will be created
        $funcResult = false;
        if (dbConnection::connect()) {
            $sql = "SELECT COUNT(*) as maxRes FROM nature";

            $queryResult = dbConnection::$connectionID->query($sql);

            if ($queryResult->num_rows > 0) {
                // output data of each row
                $funcResult = true;
                if ($row = $queryResult->fetch_assoc()) {
                    $min = 1;
                    $max = $row[maxRes];
                    $rand = rand($min,$max);
                    $position = rand(0,399);
                    $funcResult &= self::createNature($castle_id,$rand,$position);
                }
            }
        }
        return $funcResult;
    }

    public static function createNature($castle_id,$nature_id,$position)
    {
        if (dbConnection::connect()) {
            $sql = "INSERT INTO castlenature (castle_id, nature_id,position)
                              VALUES ($castle_id,$nature_id,$position)";
            if (dbConnection::$connectionID->query($sql) === TRUE) {
                return true;
            } else {
                $_SESSION["lastError"] = "Error in database while insert building $castle_id,$nature_id,$position";
                return false;
            }
        }
    }

    public static function createResources($castle_id)
    {
        $funcResult = false;
        if (dbConnection::connect()) {
            $sql = "SELECT id,startAmount FROM resources";

            $queryResult = dbConnection::$connectionID->query($sql);

            if ($queryResult->num_rows > 0) {
                // output data of each row
                $funcResult = true;
                while ($row = $queryResult->fetch_assoc()) {
                    $funcResult &= self::createResource($castle_id,$row['id'],$row['startAmount']);
                }
            }
        }
        return $funcResult;
    }

    public static function createResource($castle_id,$resource_id,$amount)
    {
        if (dbConnection::connect()) {
            $sql = "INSERT INTO castleresources (castle_id, resource_id,amount)
                              VALUES ($castle_id,$resource_id,$amount)";
            if (dbConnection::$connectionID->query($sql) === TRUE) {
                return true;
            } else {
                $_SESSION["lastError"] = "Error in database while insert resources $castle_id,$resource_id,$amount";
                return false;
            }
        }
    }



    public static function selectCastleID()
    {
        if (self::$cashedCastleID > 0) {
            return self::$cashedCastleID;
        }
        else
        {
            $player_id = $_SESSION["id"];
            if (dbConnection::connect()) {
                $sql = "SELECT current_castle_id FROM users WHERE id = '$player_id'";

                $result = dbConnection::$connectionID->query($sql);

                if ($result->num_rows > 0) {
                    // output data of each row
                    if ($row = $result->fetch_assoc()) {
                        self::$cashedCastleID = $row['current_castle_id'];
                        return self::$cashedCastleID;
                    }
                }
            }
            return -1;
        }
    }
}

?>