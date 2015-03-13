<?php
/**
 * Created by PhpStorm.
 * User: z002y7ua
 * Date: 03.03.2015
 * Time: 12:45
 */

class clInterface {

    public static $name = "MyHeroes";

    public static function drawBegin($arrCss,$arrJS)
    {
        $name = self::$name;
        print "
                <!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Strict//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd'>
                <html xmlns='http://www.w3.org/1999/xhtml'>
                    <head>
                        <title>$name</title>
                        ";

        foreach ($arrCss as $cssValue)
        {
            print "<link rel='stylesheet' type='text/css' href='css/${cssValue}'/>";
        }

        foreach ($arrJS as $jsValue)
        {
            print "<script type='text/javascript' src='js/${jsValue}'></script>";
        }


        print "
                    </head>
                    <body onmousemove='map_move(event)'>
                ";
    }


    public static function drawEnd()
    {
        print "
                    </body>
                </html>
                ";
    }

    public static function drawMap()
    {
        print "
                <div id = 'map' onmousedown='map_click(event)' >
		        </div>
                ";
    }

    public static function drawRessourceTab()
    {
        print "
                <div id = 'resourceTab'>
		        </div>
                ";
    }

    public static function drawActionTab()
    {
        print "
                <div id = 'actionTab'>
		        </div>
                ";
    }
}