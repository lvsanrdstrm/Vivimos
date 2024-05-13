
/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `vivimos` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;

USE `vivimos`;
DROP TABLE IF EXISTS `ads`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ads` (
  `id` int NOT NULL AUTO_INCREMENT,
  `headline` text,
  `county` text,
  `dwelling` text,
  `dwellingOther` text,
  `occupation` text,
  `relStatus` text,
  `partnerInfo` text,
  `childrenNum` int DEFAULT NULL,
  `childrenHome` text,
  `pets` text,
  `dog` text,
  `cat` text,
  `bird` text,
  `horse` text,
  `other` text,
  `city` text,
  `cityAlternative` text,
  `forest` text,
  `sea` text,
  `culture` text,
  `shopping` text,
  `car` tinyint(1) DEFAULT NULL,
  `carInfo` text,
  `hobbies` text,
  `presentation` text,
  `age` int DEFAULT NULL,
  `gender` text,
  `adActive` tinyint(1) DEFAULT NULL,
  `endDate` date DEFAULT NULL,
  `userId` int DEFAULT NULL,
  `endTimestamp` bigint DEFAULT NULL,
  `children` text,
  PRIMARY KEY (`id`),
  KEY `ads_users_id_fk` (`userId`),
  CONSTRAINT `ads_users_id_fk` FOREIGN KEY (`userId`) REFERENCES `users` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

LOCK TABLES `ads` WRITE;
/*!40000 ALTER TABLE `ads` DISABLE KEYS */;
INSERT INTO `ads` VALUES (2,'15 minuter från Eslöv','Skåne','slott','tomt','PK','no','zero',2,'sometimes','ds','yes','no','many','yes','no','malmö','skithåla','nope','yes','barely','sure',1,'who cares','none','',45,'gersfe',1,'2024-04-25',1,5342345,'drfs'),(3,'Grynt kultig grisfarmare','Halland','hus','stenhus','Svinaherde','yes','several',8,'yes','fsdas','three','no','no idea','yes','flies','lund','ännu värre','nope','ne','def not','some',0,'no','secret','fd',66,'',1,'2024-04-30',2,653423,'dgres'),(6,'jh5gt4fr','','Villa','','dsa','exklusiv särbo','',NULL,'','','','','','','','Mellanstor stad','','','','','shopping',NULL,'','dsa','rwe',19,'Man',1,NULL,NULL,NULL,''),(7,'y6t54r4','','Villa','','tgrfed','knasigt','',NULL,'','','','','','','','Mellanstor stad','','','','','shopping',NULL,'','trewe','jhy5gt4frde',19,'Annat',1,NULL,NULL,NULL,''),(8,'','','','','','','',NULL,'','','','','','','','','','','','','',NULL,'','','',NULL,'',1,NULL,NULL,NULL,''),(9,'gotlandsdrömmare bland alla fåren','Gotland','Gård','','drömmare','singel: ensamvarg','',NULL,'','','','','','','','Bystan','','forest','Hav / Sjö','','',NULL,'','vissla, simma, skriva, ha sex','jag är det charmigaste som finns',18,'Man',1,'2024-04-27',1,1714176000000,''),(10,'','','','','','','',NULL,'','','','','','','','','','','','','',NULL,'','','',NULL,'',1,'2024-04-30',1,1714435200000,''),(11,'bokslukande bokmal utanför uppsala','Uppsala','Lägenhet','','bibliotekarie','singel','',NULL,'','husdjur','','','','','giraffe','Mellanstor stad','','','','culture','shopping',NULL,'','gör kollage, gräver i sandlådan','jag är en lite hämmad, men ändå ganska charmant bokmal som tycker om extravaganta djur.',25,'Annat',1,'2024-04-30',1,1714435200000,'');
/*!40000 ALTER TABLE `ads` ENABLE KEYS */;
UNLOCK TABLES;
DROP TABLE IF EXISTS `bids`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bids` (
  `id` int NOT NULL AUTO_INCREMENT,
  `ad` int NOT NULL,
  `bid` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `ad_id_fk` (`ad`),
  KEY `bids_ads_id_fk` (`bid`),
  CONSTRAINT `ad_id_fk` FOREIGN KEY (`ad`) REFERENCES `ads` (`id`),
  CONSTRAINT `bids_ads_id_fk` FOREIGN KEY (`bid`) REFERENCES `ads` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

LOCK TABLES `bids` WRITE;
/*!40000 ALTER TABLE `bids` DISABLE KEYS */;
INSERT INTO `bids` VALUES (2,3,2),(3,9,2),(7,2,3),(8,2,3),(9,2,3),(10,2,3),(11,2,3),(12,2,3),(13,9,3),(14,2,3),(15,3,3),(16,2,3),(17,2,3),(18,2,3),(19,2,3),(20,6,3),(21,2,11),(22,2,11),(23,2,11),(24,2,11),(25,2,11),(26,2,11),(27,2,11),(28,2,11),(29,3,11),(30,2,11),(31,3,11);
/*!40000 ALTER TABLE `bids` ENABLE KEYS */;
UNLOCK TABLES;
DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `id` int NOT NULL AUTO_INCREMENT,
  `username` text NOT NULL,
  `email` text NOT NULL,
  `password` text NOT NULL,
  `role` text NOT NULL,
  `ad` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `users_ads_id_fk` (`ad`),
  CONSTRAINT `users_ads_id_fk` FOREIGN KEY (`ad`) REFERENCES `ads` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'rosa.parks','rosa@parks.us','bus','user',11),(2,'rosa.lux','rosa@luxemburg.de','berlin','user',9);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
