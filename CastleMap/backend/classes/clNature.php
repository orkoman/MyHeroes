<?php
/**
 * Created by PhpStorm.
 * User: z002y7ua
 * Date: 13.03.2015
 * Time: 13:52
 */

include_once "dbConnection.php";
include_once "clAMapObject.php";

class clNature extends clAMapObject{
    public static $s_id = 0;
    public function clNature($_name,$_size)
    {
        self::$s_id ++;
        parent::clAMapObject(self::$s_id,$_name,$_size);
    }

    public function createNature($_position,$_mapSize)
    {
        $size = $this->size;
        print "($_position,$size,$_mapSize)";
        if (self::checkBuild($_position,$this->size,$_mapSize)) {

            $castle_id = clGameFactory::selectCastleID(); //TODO must be moved from gameFactory
            $nature_id = $this->id;
            if (dbConnection::connect()) {
                $sql = "INSERT INTO castlenature (castle_id, nature_id,position)
                              VALUES ($castle_id,$nature_id,$_position)";
                if (dbConnection::$connectionID->query($sql) === TRUE) {
                    return true;
                } else {
                    $_SESSION["lastError"] = $_SESSION["lastError"]."Error in database while insert building $castle_id, $nature_id, $_position";
                    return false;
                }
            }
        }
        $_SESSION["lastError"] = $_SESSION["lastError"].'Couldnot createNewNature '.$this->name.' '.$_position.' '.$this->size.' '.$_mapSize;
        return false;
    }
}
