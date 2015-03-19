<?php
/**
 * Created by PhpStorm.
 * User: Z002Y7UA
 * Date: 27.02.2015
 * Time: 12:37
 */

include_once 'backend/mainIncludes.php';
include_once MAINDIR . "/backend/classes/clServer.php";


class clForschung
{

    public static function getSomething($_sql)
    {
        $requestResult[] = array();
        //print_r($_sql);
        if (dbConnection::connect())
        {
            $result = dbConnection::$connectionID->query($_sql);
            if ($result->num_rows > 0) {
                while ($row = $result->fetch_assoc()) {
                    $requestResult[] = $row;
                }
            }
            //no need by array else return ""; //TODO check if it works with empty data or should put "*";
        }
        else
        {
            Print "ERROR";
            return 0; //ERROR
        }
        return $requestResult;
    }

    public static function getCastleInfo()
    {
        //TODO more info?
        return clGameFactory::selectMapSize() . "*";
    }

    public static function getInfo()
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
            $data = self::getSomething($sql);
            $result = self::pack($data);
        }
        return "ERROR"; //error
    }

    public static function pack($_data)
    {
        foreach($_data as $row)
        {

        }
    }
}

?>