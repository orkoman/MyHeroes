<?php
/**
 * Created by PhpStorm.
 * User: Z002Y7UA
 * Date: 27.02.2015
 * Time: 12:09
 */

class dbConnection {

    public static $connectionID = null;

    public static function connect()
    {
        if (self::$connectionID == null) {
            self::$connectionID = mysqli_connect('localhost', 'root', 'Zukunft2');
            if (!self::$connectionID) {
                die('Verbindung schlug fehl: ' . mysql_error());
                return false;
            }
            mysqli_select_db(self::$connectionID,"MyHeroes");
            //return true; also true
        }
        return true;
    }

    public static function disconnect()
    {
        mysqli_close(self::$connectionID);
        self::$connectionID = null;
    }
}
?>
