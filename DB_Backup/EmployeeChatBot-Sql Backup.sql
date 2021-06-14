CREATE DATABASE  IF NOT EXISTS `employeebot` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `employeebot`;
-- MySQL dump 10.13  Distrib 8.0.25, for Win64 (x86_64)
--
-- Host: localhost    Database: employeebot
-- ------------------------------------------------------
-- Server version	8.0.25

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `category`
--

DROP TABLE IF EXISTS `category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `category` (
  `id` int NOT NULL AUTO_INCREMENT,
  `CategoryName` varchar(200) DEFAULT NULL,
  `LastModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `category`
--

LOCK TABLES `category` WRITE;
/*!40000 ALTER TABLE `category` DISABLE KEYS */;
INSERT INTO `category` VALUES (1,'FAQ','2021-06-11 23:37:43');
/*!40000 ALTER TABLE `category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `empchatquestions`
--

DROP TABLE IF EXISTS `empchatquestions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `empchatquestions` (
  `id` int NOT NULL AUTO_INCREMENT,
  `CategoryID` int DEFAULT NULL,
  `ChatQuestion` longtext,
  `ChartAnswers` longtext,
  `LastModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `empchatquestions`
--

LOCK TABLES `empchatquestions` WRITE;
/*!40000 ALTER TABLE `empchatquestions` DISABLE KEYS */;
INSERT INTO `empchatquestions` VALUES (1,1,'What is your name?','Im Bot for Employee. You can ask any questions','2021-06-13 19:49:48'),(2,1,'hi, who are you?','I am bot for employee , you can ask me any question','2021-06-13 19:52:49'),(3,1,'what\'s new?','our company is going to organize innovation program for college students in coming week.','2021-06-13 20:01:22'),(4,1,'what is the latest company news?','our company is going to organize innovation program for college students in coming week.','2021-06-13 20:03:38'),(5,1,'who is the ceo of the company?','ceo of the company is Mr.X','2021-06-13 20:04:51'),(6,1,'what are the clubs in the company?','The club called VIP club is in this company for some solcial work.','2021-06-13 20:05:51'),(7,1,'which cafe is nearest to the company?','There are two cafes in 7th floor and 11th floor','2021-06-13 20:07:00'),(8,1,'what are the reimbursement policies for me?','You have to submit all the original bills to the organization like medical expenses. The company would verify and then then will reimburse the amount up to the limit of INR 15,000 without any tax deducted on the same, as this is reimbursement of the expenses already made and is not an income.','2021-06-13 20:08:33'),(9,1,'how many leaves are left for me?','26 days left','2021-06-13 20:10:27'),(10,1,'how many leaves I have took?','23 days','2021-06-13 20:11:14'),(11,1,'what is my leave balance?','26 days left','2021-06-13 20:12:01'),(12,1,'what are the product of this company?',' It provides a range of data-center, infrastructure management and cloud computing offerings to help clients virtualize and automate their data-center environments.','2021-06-13 20:13:21'),(13,1,'is the compay is product based or service based?','service based ','2021-06-13 20:14:48'),(14,1,'what is the my role in my team?','you are the team lead for the current project ','2021-06-13 20:16:02'),(15,1,'who is my mentor?','your mentor is Mr.X','2021-06-13 20:17:05'),(17,1,'Hi','Hi','2021-06-13 20:17:05'),(18,1,'How are you?','Wonderful as always. Thanks for asking.','2021-06-13 20:17:05'),(19,1,'You\'re so sweet.','Thanks! The feeling is mutual.','2021-06-13 20:17:05'),(20,1,'Good Morning','Good Morning!','2021-06-13 20:17:05'),(21,1,'Good Evening','Good Evening!','2021-06-13 20:17:05'),(22,1,'Good Afternoon','Good Afternoon!','2021-06-13 20:17:05'),(23,1,'Good Night','Good Night!','2021-06-13 20:17:05'),(24,1,'Bye','Bye Bye!','2021-06-13 20:17:05'),(25,1,'Nice to talk you!','Thanks','2021-06-13 20:17:05'),(26,1,'What\'s Up','You can ask anything!','2021-06-13 20:17:05'),(27,1,'Are you sure?','Yes','2021-06-13 20:17:05');
/*!40000 ALTER TABLE `empchatquestions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(500) DEFAULT NULL,
  `email` varchar(500) DEFAULT NULL,
  `password` varchar(500) DEFAULT NULL,
  `UserType` varchar(45) DEFAULT NULL,
  `LastModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'admin','admin@gmail.com','admin','admin','2021-06-13 19:18:34'),(2,'Abi','abi@gmail.com','abi','user','2021-06-13 21:30:41'),(3,'abinaya','abinaya@gmail.com','abinaya','user','2021-06-13 22:43:30'),(4,'arthi','arthi@gmail.com','arthi','user','2021-06-13 22:47:30'),(5,'arthi','arts@gmail.com','arts','user','2021-06-13 22:49:55'),(6,'ram','ram@gmail.com','ram','user','2021-06-13 22:53:31'),(7,'John','john@gmail.com','john','user','2021-06-13 22:56:51');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-06-15  1:30:22
