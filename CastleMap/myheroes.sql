-- phpMyAdmin SQL Dump
-- version 4.2.11
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Erstellungszeit: 13. Mrz 2015 um 20:10
-- Server Version: 5.6.21
-- PHP-Version: 5.6.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Datenbank: `myheroes`
--

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `castlebuildings`
--

CREATE TABLE IF NOT EXISTS `castlebuildings` (
`id` int(8) unsigned NOT NULL,
  `castle_id` int(8) NOT NULL,
  `building_id` int(8) NOT NULL,
  `level` int(2) NOT NULL,
  `position` int(2) NOT NULL,
  `hitpoints` int(11) NOT NULL,
  `people` int(11) NOT NULL,
  `lastUpdate` int(11) NOT NULL,
  `status` int(1) unsigned NOT NULL COMMENT '0 - buiding, 1 - ready, 2 - not working'
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Daten für Tabelle `castlebuildings`
--

INSERT INTO `castlebuildings` (`id`, `castle_id`, `building_id`, `level`, `position`, `hitpoints`, `people`, `lastUpdate`, `status`) VALUES
(1, 1, 1, 1, 0, 1000, 0, 0, 1),
(17, 1, 3, 1, 7, 600, 0, 1426273133, 0),
(18, 1, 2, 1, 48, 200, 0, 1426273517, 0),
(19, 1, 2, 1, 45, 200, 0, 1426274193, 0);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `castlenature`
--

CREATE TABLE IF NOT EXISTS `castlenature` (
`id` int(11) unsigned NOT NULL,
  `castle_id` int(11) NOT NULL,
  `nature_id` int(11) NOT NULL,
  `position` int(11) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Daten für Tabelle `castlenature`
--

INSERT INTO `castlenature` (`id`, `castle_id`, `nature_id`, `position`) VALUES
(1, 1, 1, 61);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `castleresources`
--

CREATE TABLE IF NOT EXISTS `castleresources` (
`id` int(8) unsigned NOT NULL,
  `castle_id` int(11) NOT NULL,
  `resource_id` int(11) NOT NULL,
  `amount` int(11) NOT NULL,
  `profit` int(11) NOT NULL,
  `lastUpdate` datetime DEFAULT NULL,
  `maxAmount` int(10) unsigned NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Daten für Tabelle `castleresources`
--

INSERT INTO `castleresources` (`id`, `castle_id`, `resource_id`, `amount`, `profit`, `lastUpdate`, `maxAmount`) VALUES
(1, 1, 1, 50, 0, NULL, 1000),
(2, 1, 2, 500, 0, NULL, 1000),
(3, 1, 3, 100, 0, NULL, 1000),
(4, 1, 4, 0, 0, NULL, 1000);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `castles`
--

CREATE TABLE IF NOT EXISTS `castles` (
`id` int(8) unsigned NOT NULL,
  `name` varchar(20) COLLATE utf8_bin NOT NULL,
  `player_id` int(8) NOT NULL,
  `mapSize` int(2) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Daten für Tabelle `castles`
--

INSERT INTO `castles` (`id`, `name`, `player_id`, `mapSize`) VALUES
(1, 'noname', 1, 10);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `users`
--

CREATE TABLE IF NOT EXISTS `users` (
`id` int(8) unsigned NOT NULL,
  `name` varchar(20) COLLATE utf8_bin NOT NULL,
  `pw` varchar(20) COLLATE utf8_bin NOT NULL,
  `current_castle_id` int(8) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Daten für Tabelle `users`
--

INSERT INTO `users` (`id`, `name`, `pw`, `current_castle_id`) VALUES
(1, 'orkoman', '123', 1);

--
-- Indizes der exportierten Tabellen
--

--
-- Indizes für die Tabelle `castlebuildings`
--
ALTER TABLE `castlebuildings`
 ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `castlenature`
--
ALTER TABLE `castlenature`
 ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `castleresources`
--
ALTER TABLE `castleresources`
 ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `castles`
--
ALTER TABLE `castles`
 ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `users`
--
ALTER TABLE `users`
 ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT für exportierte Tabellen
--

--
-- AUTO_INCREMENT für Tabelle `castlebuildings`
--
ALTER TABLE `castlebuildings`
MODIFY `id` int(8) unsigned NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=20;
--
-- AUTO_INCREMENT für Tabelle `castlenature`
--
ALTER TABLE `castlenature`
MODIFY `id` int(11) unsigned NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT für Tabelle `castleresources`
--
ALTER TABLE `castleresources`
MODIFY `id` int(8) unsigned NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT für Tabelle `castles`
--
ALTER TABLE `castles`
MODIFY `id` int(8) unsigned NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT für Tabelle `users`
--
ALTER TABLE `users`
MODIFY `id` int(8) unsigned NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
