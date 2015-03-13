<?php
/**
 * Created by PhpStorm.
 * User: z002y7ua
 * Date: 12.03.2015
 * Time: 14:01
 */

class clPosition {
    public function clPosition($_x,$_y)
    {
        $this->x = $_x;
        $this->y = $_y;
    }
}

class clUtils {

    public static function buildingsNotIntersect($_p2MainPos,$_size,$_pos1,$_size1,$_mapSize)
    {
        $main_x1 = $_pos1%$_mapSize;
        $main_y1 = ($_pos1 - $main_x1)/$_mapSize;

        return (!self::intersects($_p2MainPos->x,$_p2MainPos->y,$_p2MainPos->x + $_size + 1,$_p2MainPos->y + $_size + 1,
            $main_x1,$main_y1,$main_x1 + $_size1 + 1,$main_y1 + $_size1 + 1));
    }

    public static function transform($_pos,$_mapSize)
    {
        $x = $_pos%$_mapSize;
        $y = ($_pos - $x)/$_mapSize;
        return new clPosition($x,$y);
    }

    private static function intersects($_ax1,$_ay1,$_ax2,$_ay2,$_bx1,$_by1,$_bx2,$_by2)
    {
        return ( $_ax1 < $_bx2 && $_ax2 > $_bx1 &&
            $_ay1 < $_by2 && $_ay2 > $_by1);
    }

    public static function inMap($_p2Pos,$_size,$_mapSize)
    {
        if ($_p2Pos->x < 0 ||
            $_p2Pos->y < 0 ||
            ($_p2Pos->x + $_size > $_mapSize) ||
            ($_p2Pos->y + $_size > $_mapSize))
        {
            return false;
        }
        return true;
    }

    public static function calculateDate($_status)
    {
        if ($_status == 0) {
            return time();
        }
        return 0;
    }
}