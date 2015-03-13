<?php
/**
 * Created by PhpStorm.
 * User: z002y7ua
 * Date: 03.03.2015
 * Time: 12:43
 */

include_once "dbConnection.php";
include_once "clGameFactory.php";
include_once "clUtils.php";
include_once "clGameData.php";

class clServer {

    public static function getSomething($_sql)
    {
        $requestResult = "";
        //print_r($_sql);
        $result = dbConnection::query($_sql);
        if ($result->num_rows > 0) {
            while ($row = $result->fetch_assoc()) {
                foreach($row as $key => $value)
                {
                    $code = substr($key,0,3);
                    if ($code == "_b_")
                    {
                        $value = clGameData::getBuildingDataByID($value);
                        $value = $value->requestData();
                    }
                    else if ($code == "_n_")
                    {
                        $value = clGameData::getNatureDataByID($value);
                        $value = $value->requestData();
                    }
                    else if ($code == "_r_")
                    {
                        $value = clGameData::getResourceByID($value);
                        $value = $value->requestData();
                    }
                    $requestResult = $requestResult . "${value}_";
                }
                $requestResult = substr($requestResult ,0,-1)."*";
            }
        }
        else return ""; //TODO check if it works with empty data or should put "*";

        return $requestResult;
    }

    public static function getCastleInfo()
    {
        //TODO more info?
        return clGameFactory::selectMapSize()."*";
    }

    public static function getBuildings()
    {
        $castle_id = clGameFactory::selectCastleID();
        if ($castle_id != -1) {
            $sql = "SELECT building_id as _b_id,
                           level,
                           position,
                           id as cb_id,
                           status,
                           lastUpdate
                    FROM castlebuildings
                    WHERE castle_id = '$castle_id'";
            return self::getSomething($sql);
        }
        return "ERROR"; //error
    }

    public static function getNature()
    {
        $castle_id = clGameFactory::selectCastleID();
        if ($castle_id != -1) {
            $sql = "SELECT nature_id as _n_id,
                           position,
                           id as cn_id
                    FROM castlenature
                    WHERE castle_id = '$castle_id'";
            return self::getSomething($sql);
        }
        return "ERROR"; //error
    }

    public static function getResources()
    {
        $castle_id = clGameFactory::selectCastleID();
        if ($castle_id != -1) {
            $sql = "SELECT resource_id as _r_id,
                           amount as amount,
                           profit as profit,
                           maxAmount as maxAmount
                    FROM castleresources
                    WHERE castleresources.castle_id = '$castle_id'";
            return self::getSomething($sql);
        }
        return "ERROR"; //error
    }

    public static function safeReturn($_result)
    {
        $length = dechex(strlen($_result));
        $lengthOfLength = strlen($length);

        switch($lengthOfLength)
        {
            case 1:
                print "000".$length . $_result;
                return;
            case 2:
                print "00".$length . $_result;
                return;
            case 3:
                print "0".$length . $_result;
                return;
            case 4:
                print $length . $_result;
                return;
            case 0:
                print "   lengthLength = 0)";
                return;
            default:
                print "   lengthLength > 4)";
        }
    }





}


?>