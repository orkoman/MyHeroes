<?php
/**
 * Created by PhpStorm.
 * User: Z002Y7UA
 * Date: 27.02.2015
 * Time: 14:12
 */

session_start();
include_once "backend/mainIncludes.php";

if (isset($_SESSION['id'])) {

    include_once MAINDIR . "/backend/classes/clInterface.php";
    include_once MAINDIR . "/backend/classes/clServer.php";

    clInterface::drawBegin(array('main.css'), array('ajaxHelper.js','utils.js','people.js','map.js','resources.js','actions.js','game.js'));

    clInterface::drawRessourceTab();
    clInterface::drawActionTab();
    clInterface::drawMap();

    clInterface::drawEnd();

    $size = substr(clServer::getCastleInfo() ,0,-1); //TODO not only size, but also maybe name
    $buildings = clServer::getBuildings();
    $nature = clServer::getNature();
    $resources = clServer::getResources();

    $mainUri = MAINURI;

//TODO OLEG remove this
    print "
    <script type='text/javascript'>
        var g_Game = new clGame('$mainUri',$size,'$buildings','$nature','$resources');
    </script>
        ";
}
else
{
    header("Location:".MAINURI."/loginForm.php");
}
?>