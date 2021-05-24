-- MySQL dump 10.13  Distrib 8.0.22, for Win64 (x86_64)
--
-- Host: localhost    Database: fidelity
-- ------------------------------------------------------
-- Server version	8.0.22

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
  `category_id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `active` tinyint NOT NULL DEFAULT '1',
  PRIMARY KEY (`category_id`),
  UNIQUE KEY `name_UNIQUE` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `category`
--

LOCK TABLES `category` WRITE;
/*!40000 ALTER TABLE `category` DISABLE KEYS */;
INSERT INTO `category` VALUES (1,'CDs',1),(2,'Livros',1);
/*!40000 ALTER TABLE `category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `company`
--

DROP TABLE IF EXISTS `company`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `company` (
  `company_id` int NOT NULL AUTO_INCREMENT,
  `company_name` varchar(100) NOT NULL,
  `trade_name` varchar(100) NOT NULL,
  `employer_identification_number` varchar(14) NOT NULL,
  `registration_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `active` tinyint NOT NULL DEFAULT '1',
  PRIMARY KEY (`company_id`),
  UNIQUE KEY `employer_identification_number_UNIQUE` (`employer_identification_number`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `company`
--

LOCK TABLES `company` WRITE;
/*!40000 ALTER TABLE `company` DISABLE KEYS */;
INSERT INTO `company` VALUES (1,'Empresa 1','Empresa 1','12345678910123','2021-05-21 01:15:06',1),(2,'Empresa 2','Empresa 2','12345678910124','2021-05-21 01:15:06',1);
/*!40000 ALTER TABLE `company` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order`
--

DROP TABLE IF EXISTS `order`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `order` (
  `order_id` int NOT NULL AUTO_INCREMENT,
  `product_id` int NOT NULL,
  `user_id` int NOT NULL,
  `user_address_id` int NOT NULL,
  `order_status_id` char(1) NOT NULL DEFAULT 'P',
  `points_value` decimal(15,2) NOT NULL,
  `registration_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`order_id`),
  KEY `FK_ORD__idx` (`product_id`),
  KEY `FK_ORD_USE_idx` (`user_id`),
  KEY `FK_ORD_USD_idx` (`user_address_id`),
  KEY `FK_ID_ORD_UST_idx` (`order_status_id`),
  CONSTRAINT `FK_ID_ORD_PRO` FOREIGN KEY (`product_id`) REFERENCES `product` (`product_id`),
  CONSTRAINT `FK_ID_ORD_UAD` FOREIGN KEY (`user_address_id`) REFERENCES `user_address` (`user_address_id`),
  CONSTRAINT `FK_ID_ORD_USE` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`),
  CONSTRAINT `FK_ID_ORD_UST` FOREIGN KEY (`order_status_id`) REFERENCES `order_status` (`order_status_id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order`
--

LOCK TABLES `order` WRITE;
/*!40000 ALTER TABLE `order` DISABLE KEYS */;
INSERT INTO `order` VALUES (1,1,3,5,'D',5.00,'2021-05-20 01:53:24'),(11,1,3,6,'P',5.00,'2021-05-21 02:41:10');
/*!40000 ALTER TABLE `order` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_history`
--

DROP TABLE IF EXISTS `order_history`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `order_history` (
  `order_history_id` int NOT NULL AUTO_INCREMENT,
  `order_id` int NOT NULL,
  `order_status_id` char(1) NOT NULL,
  `details` varchar(100) NOT NULL,
  `registration_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`order_history_id`),
  KEY `FK_ORH_ORD_idx` (`order_id`),
  KEY `FK_ID_ORH_OST_idx` (`order_status_id`),
  CONSTRAINT `FK_ID_ORH_ORD` FOREIGN KEY (`order_id`) REFERENCES `order` (`order_id`),
  CONSTRAINT `FK_ID_ORH_OST` FOREIGN KEY (`order_status_id`) REFERENCES `order_status` (`order_status_id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_history`
--

LOCK TABLES `order_history` WRITE;
/*!40000 ALTER TABLE `order_history` DISABLE KEYS */;
INSERT INTO `order_history` VALUES (1,1,'P','Produto está sendo preparado.','2021-05-20 01:53:24'),(2,1,'T','Saiu do posto de distruibuição em Campinas - SP.','2021-05-20 23:53:24'),(3,1,'T','Chegou no posto de distruibuição em Campo belo - SP.','2021-05-20 07:53:24'),(4,1,'O','Saiu para entrega.','2021-05-20 16:53:24'),(5,1,'D','Produto entregue.','2021-05-20 21:53:24'),(7,11,'P','Produto está sendo preparado.','2021-05-21 02:41:10');
/*!40000 ALTER TABLE `order_history` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_status`
--

DROP TABLE IF EXISTS `order_status`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `order_status` (
  `order_status_id` char(1) NOT NULL,
  `description` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`order_status_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_status`
--

LOCK TABLES `order_status` WRITE;
/*!40000 ALTER TABLE `order_status` DISABLE KEYS */;
INSERT INTO `order_status` VALUES ('C','Cancelado pelo usuário'),('D','Entregue.'),('N','Não entregue.'),('O','Saiu para entrega.'),('P','Preparando o produto.'),('T','Em tráfego.');
/*!40000 ALTER TABLE `order_status` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product`
--

DROP TABLE IF EXISTS `product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product` (
  `product_id` int NOT NULL AUTO_INCREMENT,
  `subcategory_id` int NOT NULL,
  `name` varchar(100) NOT NULL,
  `points_value` decimal(15,2) NOT NULL,
  `registration_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `active` tinyint NOT NULL DEFAULT '1',
  PRIMARY KEY (`product_id`),
  KEY `subcategory_id_idx` (`subcategory_id`),
  CONSTRAINT `FK_ID_PRO_SUB` FOREIGN KEY (`subcategory_id`) REFERENCES `subcategory` (`subcategory_id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product`
--

LOCK TABLES `product` WRITE;
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product` VALUES (1,2,'Kind of Blue — Miles Davis',5.00,'2021-05-20 21:53:24',1),(2,2,'A Love Supreme — John Coltrane',7.00,'2021-05-20 21:53:24',1),(3,1,'Culture Club - Life',9.00,'2021-05-20 21:53:24',1),(4,1,'Stevie B - In My Eyes',6.00,'2021-05-20 21:53:24',1),(5,3,'Bob Marley - Uprising Live!',8.00,'2021-05-20 21:53:24',0),(6,4,'As Crônicas de Nárnia – C. S. Lewis',12.00,'2021-05-20 21:53:24',1),(7,4,'O Hobbit - J. R. R. Tolkien',14.00,'2021-05-20 21:53:24',1),(8,5,'Simplesmente acontece - Cecelia Ahern',11.00,'2021-05-20 21:53:24',1),(9,5,'A Culpa é das Estrelas - John Green',13.00,'2021-05-20 21:53:24',1);
/*!40000 ALTER TABLE `product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subcategory`
--

DROP TABLE IF EXISTS `subcategory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `subcategory` (
  `subcategory_id` int NOT NULL AUTO_INCREMENT,
  `category_id` int NOT NULL,
  `name` varchar(100) NOT NULL,
  `active` tinyint NOT NULL DEFAULT '1',
  PRIMARY KEY (`subcategory_id`),
  KEY `FK_ID_SUB_CAT_idx` (`category_id`),
  CONSTRAINT `FK_ID_SUB_CAT` FOREIGN KEY (`category_id`) REFERENCES `category` (`category_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subcategory`
--

LOCK TABLES `subcategory` WRITE;
/*!40000 ALTER TABLE `subcategory` DISABLE KEYS */;
INSERT INTO `subcategory` VALUES (1,1,'Pop',1),(2,1,'Jazz',1),(3,1,'Reggae',0),(4,2,'Aventura',1),(5,2,'Romance',1);
/*!40000 ALTER TABLE `subcategory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `user_id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `birth_date` date NOT NULL,
  `individual_taxpayer_registration` varchar(11) NOT NULL,
  `email` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL,
  `cellphone` varchar(15) DEFAULT NULL,
  `current_points_balance` decimal(15,2) NOT NULL DEFAULT '0.00',
  `registration_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `active` tinyint NOT NULL DEFAULT '1',
  PRIMARY KEY (`user_id`),
  UNIQUE KEY `email_UNIQUE` (`email`),
  UNIQUE KEY `individual_taxpayer_registration_UNIQUE` (`individual_taxpayer_registration`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'Maria','2000-06-20','33523686008','teste1@hotmail.com','XgKEeIjnxrObK4aiJY6yNw==','71981818283',35.00,'2021-04-20 21:53:24',1),(2,'João','2000-05-23','67453719011','teste2@hotmail.com','XgKEeIjnxrObK4aiJY6yNw==','71981818283',0.00,'2021-04-20 21:53:24',0),(3,'Larissa','2000-02-11','65603584025','teste3@hotmail.com','XgKEeIjnxrObK4aiJY6yNw==','71981818283',6.00,'2021-04-20 21:53:24',1);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_address`
--

DROP TABLE IF EXISTS `user_address`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_address` (
  `user_address_id` int NOT NULL AUTO_INCREMENT,
  `user_id` int NOT NULL,
  `number` int NOT NULL,
  `address` varchar(100) NOT NULL,
  `zip_code` varchar(8) DEFAULT NULL,
  `state` varchar(2) NOT NULL,
  `city` varchar(100) NOT NULL,
  `district` varchar(100) NOT NULL,
  `information_additional` varchar(100) DEFAULT NULL,
  `registration_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `active` tinyint NOT NULL DEFAULT '1',
  PRIMARY KEY (`user_address_id`),
  KEY `FK_ID_ADR_USE_idx` (`user_id`),
  CONSTRAINT `FK_ID_ADR_USE` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_address`
--

LOCK TABLES `user_address` WRITE;
/*!40000 ALTER TABLE `user_address` DISABLE KEYS */;
INSERT INTO `user_address` VALUES (1,1,10,'Rua teste 1','40712321','BA','Salvador','Barra','Próximo a padaria teste 1','2021-05-20 22:09:09',1),(2,1,11,'Rua teste 2','40422344','BA','Salvador','Pituba','Próximo a padaria teste 2','2021-05-21 01:15:06',1),(3,1,12,'Rua teste 2','40312566','BA','Salvador','Plataforma','Próximo a padaria teste 3','2021-05-21 01:15:06',1),(4,2,1,'Rua teste 5','40730201','SP','São Paulo','Bela Vista','Próximo a farmacia teste 1','2021-05-21 01:15:06',1),(5,2,4,'Rua teste 7','40442239','SP','São Paulo','Campo Belo','Próximo a farmacia teste 2','2021-05-21 01:15:06',1),(6,3,2,'Rua teste 9','40727490','RJ','Rio de Janeiro','Laranjeiras','Próximo a loja teste 4','2021-05-21 01:15:06',1),(7,3,2,'Rua teste 8','40726255','RJ','Rio de Janeiro','Copacabana','Próximo a loja teste 6','2021-05-21 01:15:06',0),(8,1,10,'Rua teste','40712321','BA','Cidade','Barra','Próximo a padaria teste','2021-05-22 14:59:15',1),(9,1,10,'Rua teste','40712321','BA','Cidade','Barra','Próximo a padaria teste','2021-05-22 17:12:56',1),(10,1,10,'Rua teste','40712321','BA','Cidade','Barra','Próximo a padaria teste','2021-05-22 17:17:08',1);
/*!40000 ALTER TABLE `user_address` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_point_company`
--

DROP TABLE IF EXISTS `user_point_company`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_point_company` (
  `user_point_company_id` int NOT NULL AUTO_INCREMENT,
  `user_id` int NOT NULL,
  `company_id` int NOT NULL COMMENT 'Companhia parceira em que o usuário adquiriu os pontos.',
  `user_point_status_id` char(1) NOT NULL DEFAULT 'P',
  `points_value` decimal(15,2) NOT NULL,
  `registration_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`user_point_company_id`),
  KEY `FK_UPH_USE_idx` (`user_id`),
  KEY `FK_UPH_PAC_idx` (`company_id`),
  KEY `FK_ID_UPC_UPS_idx` (`user_point_status_id`),
  CONSTRAINT `FK_ID_UPC_PAC` FOREIGN KEY (`company_id`) REFERENCES `company` (`company_id`),
  CONSTRAINT `FK_ID_UPC_UPS` FOREIGN KEY (`user_point_status_id`) REFERENCES `user_point_status` (`user_point_status_id`),
  CONSTRAINT `FK_ID_UPC_USE` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_point_company`
--

LOCK TABLES `user_point_company` WRITE;
/*!40000 ALTER TABLE `user_point_company` DISABLE KEYS */;
INSERT INTO `user_point_company` VALUES (1,1,1,'C',2.00,'2021-05-01 21:53:24'),(2,1,2,'R',22.00,'2021-05-02 21:53:24'),(3,1,1,'R',13.00,'2021-05-03 21:53:24'),(4,1,1,'P',5.00,'2021-05-04 21:53:24'),(5,2,1,'C',6.00,'2021-05-05 21:53:24'),(6,3,1,'R',7.00,'2021-05-06 21:53:24'),(7,3,2,'R',9.00,'2021-05-08 21:53:24');
/*!40000 ALTER TABLE `user_point_company` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_point_history`
--

DROP TABLE IF EXISTS `user_point_history`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_point_history` (
  `user_point_history_id` int NOT NULL AUTO_INCREMENT,
  `user_id` int NOT NULL,
  `point_balance` decimal(15,2) NOT NULL,
  `registration_date` datetime NOT NULL,
  PRIMARY KEY (`user_point_history_id`),
  KEY `FK_UPH_USE_idx` (`user_id`),
  CONSTRAINT `FK_ID_UPH_USE` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_point_history`
--

LOCK TABLES `user_point_history` WRITE;
/*!40000 ALTER TABLE `user_point_history` DISABLE KEYS */;
INSERT INTO `user_point_history` VALUES (1,1,22.00,'2021-05-02 21:53:24'),(2,1,35.00,'2021-05-03 21:53:24'),(3,3,7.00,'2021-05-06 21:53:24'),(4,3,16.00,'2021-05-08 21:53:24'),(5,3,11.00,'2021-05-20 01:53:24'),(6,3,6.00,'2021-05-21 02:41:10');
/*!40000 ALTER TABLE `user_point_history` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_point_status`
--

DROP TABLE IF EXISTS `user_point_status`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_point_status` (
  `user_point_status_id` char(1) NOT NULL,
  `description` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`user_point_status_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_point_status`
--

LOCK TABLES `user_point_status` WRITE;
/*!40000 ALTER TABLE `user_point_status` DISABLE KEYS */;
INSERT INTO `user_point_status` VALUES ('C','Cancelado pela empresa.'),('P','Aguardando receber os pontos no saldo.'),('R','Pontos adicionado ao seu saldo.');
/*!40000 ALTER TABLE `user_point_status` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-05-23 19:49:46
