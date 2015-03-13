<?php
/**
 * Created by PhpStorm.
 * User: Z002Y7UA
 * Date: 27.02.2015
 * Time: 15:06
 */

include_once "dbConnection.php";
include_once "clFormul.php";
include_once "clUtils.php";
include_once "clGameData.php";

class clGameFactory {

    public static $cashedCastleID = 0;
    public static $cashedMapSize = 0;

    public static function createCastle()
    {
        $castleType = 1; //1 - castle, TODO maybe get by name
        $mapSize = clGameData::getStartMapSize();
        $castleData = clGameData::getBuildingDataByID($castleType);
        $castlePosition = 0;
        $player_id = $_SESSION["id"];
        if (dbConnection::connect()) {
            $sql = "INSERT INTO castles (name, player_id,mapSize)
                              VALUES ('noname','$player_id', $mapSize)";

            if (dbConnection::$connectionID->query($sql) === TRUE) {
                $castle_id = dbConnection::$connectionID->insert_id;
                self::$cashedCastleID = $castle_id;

                $sql = "UPDATE users set current_castle_id = '$castle_id' where id = '$player_id'";
                if (dbConnection::$connectionID->query($sql) === TRUE) {
                    $result = $castleData->createNewBuilding($castlePosition,$mapSize,1); //TODO 1 - status
                    $result &= clGameData::createResources();
                    $result &= clGameData::createNatureAll($castlePosition,$castleData->size,$mapSize);
                    print($result);
                    return $result;
                }
            } else {
                $_SESSION["lastError"] = $_SESSION["lastError"]."Error in database while insert castle";
            }
        }
        return false;
    }

    public static function selectMapSize()
    {
        if (self::$cashedMapSize > 0) {
            return self::$cashedMapSize;
        }
        else
        {
            $castle_id = clGameFactory::selectCastleID();
            if ($castle_id != -1 && dbConnection::connect()) {
                $sql = "SELECT mapSize FROM castles WHERE id = '$castle_id'";

                $result = dbConnection::$connectionID->query($sql);

                if ($result->num_rows > 0) {
                    // output data of each row
                    if ($row = $result->fetch_assoc()) {
                        self::$cashedMapSize = $row['mapSize'];
                        return self::$cashedMapSize;
                    }
                }
            }
            print "Error cant get castle id!!!";
            return -1;
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
            print "Error cant get castle id!!!";
            return -1;
        }
    }
}

?>