-- phpMyAdmin SQL Dump
-- version 4.2.11
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Erstellungszeit: 06. Mrz 2015 um 20:04
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
-- Tabellenstruktur für Tabelle `buildings`
--

CREATE TABLE IF NOT EXISTS `buildings` (
`id` int(8) unsigned NOT NULL,
  `name` varchar(20) COLLATE utf8_bin NOT NULL,
  `size` int(2) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Daten für Tabelle `buildings`
--

INSERT INTO `buildings` (`id`, `name`, `size`) VALUES
(1, 'castle', 4),
(2, 'house', 2);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `castlebuildings`
--

CREATE TABLE IF NOT EXISTS `castlebuildings` (
`id` int(8) unsigned NOT NULL,
  `castle_id` int(8) NOT NULL,
  `building_id` int(8) NOT NULL,
  `level` int(2) NOT NULL,
  `position` int(2) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Daten für Tabelle `castlebuildings`
--

INSERT INTO `castlebuildings` (`id`, `castle_id`, `building_id`, `level`, `position`) VALUES
(1, 1, 1, 1, 16),
(2, 2, 1, 1, 16);

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
(1, 2, 1, 66);

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
  `lastupdate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Daten für Tabelle `castleresources`
--

INSERT INTO `castleresources` (`id`, `castle_id`, `resource_id`, `amount`, `profit`, `lastupdate`) VALUES
(1, 1, 1, 50, 0, '2015-03-04 15:51:53'),
(2, 1, 2, 500, 0, '2015-03-04 15:51:53'),
(3, 1, 3, 100, 0, '2015-03-04 15:51:53'),
(4, 2, 1, 50, 0, '2015-03-04 18:51:51'),
(5, 2, 2, 500, 0, '2015-03-04 18:51:51'),
(6, 2, 3, 100, 0, '2015-03-04 18:51:51');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `castles`
--

CREATE TABLE IF NOT EXISTS `castles` (
`id` int(8) unsigned NOT NULL,
  `name` varchar(20) COLLATE utf8_bin NOT NULL,
  `player_id` int(8) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Daten für Tabelle `castles`
--

INSERT INTO `castles` (`id`, `name`, `player_id`) VALUES
(1, 'noname', 1),
(2, 'noname', 2);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `nature`
--

CREATE TABLE IF NOT EXISTS `nature` (
`id` int(10) unsigned NOT NULL,
  `name` varchar(20) COLLATE utf8_bin NOT NULL,
  `size` int(2) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Daten für Tabelle `nature`
--

INSERT INTO `nature` (`id`, `name`, `size`) VALUES
(1, 'wood', 3),
(2, 'stone', 3);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `resources`
--

CREATE TABLE IF NOT EXISTS `resources` (
`id` int(8) NOT NULL,
  `name` varchar(20) COLLATE utf8_bin NOT NULL,
  `startAmount` int(11) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Daten für Tabelle `resources`
--

INSERT INTO `resources` (`id`, `name`, `startAmount`) VALUES
(1, 'people', 50),
(2, 'gold', 500),
(3, 'lumber', 100);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `users`
--

CREATE TABLE IF NOT EXISTS `users` (
`id` int(8) unsigned NOT NULL,
  `name` varchar(20) COLLATE utf8_bin NOT NULL,
  `pw` varchar(20) COLLATE utf8_bin NOT NULL,
  `current_castle_id` int(8) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Daten für Tabelle `users`
--

INSERT INTO `users` (`id`, `name`, `pw`, `current_castle_id`) VALUES
(2, 'orkoman', '123', 2);

--
-- Indizes der exportierten Tabellen
--

--
-- Indizes für die Tabelle `buildings`
--
ALTER TABLE `buildings`
 ADD PRIMARY KEY (`id`);

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
-- Indizes für die Tabelle `nature`
--
ALTER TABLE `nature`
 ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `resources`
--
ALTER TABLE `resources`
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
-- AUTO_INCREMENT für Tabelle `buildings`
--
ALTER TABLE `buildings`
MODIFY `id` int(8) unsigned NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT für Tabelle `castlebuildings`
--
ALTER TABLE `castlebuildings`
MODIFY `id` int(8) unsigned NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT für Tabelle `castlenature`
--
ALTER TABLE `castlenature`
MODIFY `id` int(11) unsigned NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT für Tabelle `castleresources`
--
ALTER TABLE `castleresources`
MODIFY `id` int(8) unsigned NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT für Tabelle `castles`
--
ALTER TABLE `castles`
MODIFY `id` int(8) unsigned NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT für Tabelle `nature`
--
ALTER TABLE `nature`
MODIFY `id` int(10) unsigned NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT für Tabelle `resources`
--
ALTER TABLE `resources`
MODIFY `id` int(8) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT für Tabelle `users`
--
ALTER TABLE `users`
MODIFY `id` int(8) unsigned NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
