# ************************************************************
# Sequel Pro SQL dump
# Version 4541
#
# http://www.sequelpro.com/
# https://github.com/sequelpro/sequelpro
#
# Host: fr4nc3.com (MySQL 5.7.23-23)
# Database: frfounct_mta_demo
# Generation Time: 2021-02-15 17:23:35 +0000
# ************************************************************


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


# Dump of table data_trip
# ------------------------------------------------------------

CREATE TABLE `data_trip` (
  `trip_id` varchar(36) COLLATE utf8mb4_unicode_ci NOT NULL,
  `car_type` varchar(36) COLLATE utf8mb4_unicode_ci NOT NULL,
  `pickup_borough` int(10) NOT NULL DEFAULT '265',
  `dropoff_borough` int(10) NOT NULL DEFAULT '265',
  `rate_code_id` int(10) NOT NULL DEFAULT '1',
  `fare_amount` decimal(10,3) NOT NULL DEFAULT '0.000',
  `passenger_count` int(10) NOT NULL DEFAULT '1',
  `sr_flag` int(10) NOT NULL DEFAULT '0',
  `pay_type` int(10) NOT NULL DEFAULT '0',
  `trip_distance` decimal(10,3) NOT NULL DEFAULT '0.000',
  `start_date` datetime NOT NULL,
  `end_date` datetime NOT NULL,
  PRIMARY KEY (`trip_id`),
  UNIQUE KEY `trip_id_UNIQUE` (`trip_id`),
  KEY `trip_id` (`trip_id`),
  KEY `pickup_brough` (`pickup_borough`),
  KEY `dropoff_borough` (`dropoff_borough`),
  CONSTRAINT `data_trip_ibfk_1` FOREIGN KEY (`pickup_borough`) REFERENCES `taxi_zone` (`location_id`),
  CONSTRAINT `data_trip_ibfk_2` FOREIGN KEY (`dropoff_borough`) REFERENCES `taxi_zone` (`location_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;



# Dump of table taxi_zone
# ------------------------------------------------------------

CREATE TABLE `taxi_zone` (
  `location_id` int(10) NOT NULL,
  `borough_name` varchar(13) DEFAULT NULL,
  `zone` varchar(45) DEFAULT NULL,
  `service_zone` varchar(12) DEFAULT NULL,
  PRIMARY KEY (`location_id`),
  KEY `br_name_idx` (`borough_name`),
  FULLTEXT KEY `z_full_search` (`zone`),
  FULLTEXT KEY `service_zone` (`service_zone`),
  FULLTEXT KEY `borough_name` (`borough_name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;




/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
