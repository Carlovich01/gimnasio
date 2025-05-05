-- MySQL dump 10.13  Distrib 8.0.42, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: goatym2
-- ------------------------------------------------------
-- Server version	8.0.42

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
-- Table structure for table `asistencia`
--

DROP TABLE IF EXISTS `asistencia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `asistencia` (
  `id_asistencia` bigint unsigned NOT NULL AUTO_INCREMENT COMMENT 'Usar BIGINT si se esperan muchos check-ins',
  `id_miembro` int unsigned DEFAULT NULL COMMENT 'Miembro que realizó el check-in',
  `fecha_hora_checkin` timestamp NULL DEFAULT CURRENT_TIMESTAMP COMMENT 'Fecha y hora exactas del intento de ingreso',
  `resultado` enum('Exitoso','Fallido_DNI_NoEncontrado','Fallido_Membresia_Inactiva','Fallido_No_Hay_Membresia','Fallido_Otro') NOT NULL COMMENT 'Resultado de la validación del check-in',
  `id_membresia_valida` int unsigned DEFAULT NULL COMMENT 'Opcional: ID de la membresía que permitió el acceso exitoso',
  PRIMARY KEY (`id_asistencia`),
  KEY `fk_asistencia_membresia_valida` (`id_membresia_valida`),
  KEY `idx_asistencia_miembro` (`id_miembro`),
  KEY `idx_asistencia_fecha` (`fecha_hora_checkin`),
  KEY `idx_asistencia_resultado` (`resultado`),
  CONSTRAINT `fk_asistencia_membresia_valida` FOREIGN KEY (`id_membresia_valida`) REFERENCES `membresias_miembro` (`id_membresia`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `fk_asistencia_miembro` FOREIGN KEY (`id_miembro`) REFERENCES `miembros` (`id_miembro`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=83 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Log de ingresos (check-ins) de los miembros';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `asistencia`
--

LOCK TABLES `asistencia` WRITE;
/*!40000 ALTER TABLE `asistencia` DISABLE KEYS */;
INSERT INTO `asistencia` VALUES (1,1,'2025-05-03 22:01:35','Exitoso',1),(3,3,'2025-05-03 22:29:37','Exitoso',12),(11,1,'2025-05-03 22:45:55','Exitoso',1),(18,1,'2025-05-03 22:56:28','Exitoso',1),(19,1,'2025-05-03 22:57:10','Exitoso',1),(25,1,'2025-05-03 23:08:30','Exitoso',1),(29,4,'2025-05-03 23:14:01','Exitoso',14),(30,4,'2025-05-03 23:14:29','Exitoso',14),(33,1,'2025-05-04 02:40:29','Exitoso',1),(34,1,'2025-05-04 13:08:31','Exitoso',1),(36,1,'2025-05-04 14:49:06','Exitoso',1),(37,1,'2025-08-06 18:26:06','Fallido_Membresia_Inactiva',NULL),(38,1,'2025-08-06 18:26:06','Fallido_Membresia_Inactiva',NULL),(39,1,'2025-08-06 18:45:41','Fallido_Membresia_Inactiva',NULL),(40,1,'2025-08-06 18:47:43','Exitoso',2),(41,1,'2025-08-06 19:12:23','Exitoso',2),(42,1,'2025-08-06 19:13:50','Exitoso',2),(43,1,'2025-08-06 19:14:58','Exitoso',2),(44,1,'2025-08-06 19:16:48','Exitoso',2),(45,1,'2025-08-06 19:20:43','Exitoso',2),(46,1,'2025-08-06 19:20:58','Exitoso',2),(47,1,'2025-08-06 19:25:19','Exitoso',2),(48,1,'2025-08-06 19:28:49','Exitoso',2),(49,1,'2025-08-06 19:29:13','Exitoso',2),(50,1,'2025-08-06 19:32:10','Exitoso',2),(51,1,'2025-08-06 19:32:37','Exitoso',2),(52,1,'2025-08-06 19:32:56','Exitoso',2),(53,1,'2025-08-06 19:35:59','Exitoso',2),(54,1,'2025-08-06 19:37:52','Exitoso',2),(55,1,'2025-08-06 19:38:17','Exitoso',2),(56,18,'2025-08-06 19:49:39','Exitoso',24),(57,18,'2025-08-06 19:50:42','Exitoso',24),(58,18,'2025-08-06 19:52:48','Exitoso',24),(59,18,'2025-08-06 19:54:56','Exitoso',24),(60,1,'2025-08-06 19:55:31','Exitoso',2),(61,18,'2025-08-06 19:56:26','Exitoso',24),(62,18,'2025-08-06 19:58:20','Exitoso',24),(63,18,'2025-08-06 20:04:08','Exitoso',24),(64,18,'2025-08-06 20:04:25','Exitoso',24),(65,18,'2025-08-06 20:05:14','Exitoso',24),(66,18,'2025-08-06 20:07:14','Exitoso',24),(67,1,'2025-08-06 20:07:43','Exitoso',2),(68,3,'2025-08-06 20:08:55','Fallido_Membresia_Inactiva',NULL),(69,18,'2025-08-06 20:09:07','Exitoso',24),(70,18,'2025-08-06 20:10:21','Exitoso',24),(71,18,'2025-08-06 20:11:31','Exitoso',24),(72,18,'2025-08-06 20:14:20','Exitoso',24),(73,18,'2025-08-06 20:16:10','Exitoso',24),(74,18,'2025-08-06 20:16:45','Exitoso',24),(75,18,'2025-08-06 20:17:28','Exitoso',24),(76,3,'2025-08-06 20:17:36','Fallido_Membresia_Inactiva',NULL),(77,19,'2025-05-04 20:38:05','Fallido_No_Hay_Membresia',NULL),(78,1,'2025-05-04 21:22:18','Exitoso',2),(79,1,'2025-08-14 21:23:29','Exitoso',2),(80,1,'2025-05-05 11:19:29','Exitoso',2),(81,1,'2025-05-05 11:23:53','Exitoso',2),(82,33,'2025-05-05 19:51:15','Exitoso',34);
/*!40000 ALTER TABLE `asistencia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `membresias_miembro`
--

DROP TABLE IF EXISTS `membresias_miembro`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `membresias_miembro` (
  `id_membresia` int unsigned NOT NULL AUTO_INCREMENT,
  `id_miembro` int unsigned NOT NULL COMMENT 'Referencia al miembro',
  `id_plan` int unsigned NOT NULL COMMENT 'Referencia al plan contratado',
  `fecha_inicio` date NOT NULL COMMENT 'Fecha de inicio de la vigencia de esta membresía',
  `fecha_fin` date NOT NULL COMMENT 'Fecha de fin de la vigencia de esta membresía (calculada)',
  `estado_membresia` enum('Activa','Inactiva') NOT NULL DEFAULT 'Activa' COMMENT 'Estado actual de esta instancia de membresía',
  `fecha_registro` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `ultima_modificacion` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id_membresia`),
  KEY `idx_membresia_miembro` (`id_miembro`),
  KEY `idx_membresia_plan` (`id_plan`),
  KEY `idx_membresia_fechas` (`fecha_inicio`,`fecha_fin`),
  KEY `idx_membresia_estado` (`estado_membresia`),
  CONSTRAINT `fk_membresia_miembro` FOREIGN KEY (`id_miembro`) REFERENCES `miembros` (`id_miembro`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_membresia_plan` FOREIGN KEY (`id_plan`) REFERENCES `planes_membresia` (`id_plan`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Instancias de suscripción de los miembros a planes';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `membresias_miembro`
--

LOCK TABLES `membresias_miembro` WRITE;
/*!40000 ALTER TABLE `membresias_miembro` DISABLE KEYS */;
INSERT INTO `membresias_miembro` VALUES (1,1,1,'2025-06-04','2025-07-04','Inactiva','2025-05-03 14:23:01','2025-08-06 17:28:56'),(2,1,3,'2025-08-06','2025-09-05','Inactiva','2025-05-03 14:29:00','2025-11-05 13:43:05'),(3,1,2,'2025-05-03','2025-05-10','Inactiva','2025-05-03 16:01:44','2025-06-04 15:17:28'),(4,2,3,'2025-05-03','2025-06-02','Inactiva','2025-05-03 16:06:08','2025-06-04 15:17:28'),(5,2,3,'2025-05-03','2025-06-02','Inactiva','2025-05-03 19:39:25','2025-06-04 15:17:28'),(6,2,2,'2025-05-03','2025-05-10','Inactiva','2025-05-03 19:40:01','2025-06-04 15:17:28'),(7,2,11,'2025-11-05','2025-12-05','Activa','2025-05-03 19:43:06','2025-11-05 13:43:30'),(8,1,20,'2025-06-04','2025-06-19','Inactiva','2025-05-03 20:11:27','2025-07-04 17:25:40'),(9,1,2,'2025-05-03','2025-05-10','Inactiva','2025-05-03 20:30:39','2025-06-04 15:17:28'),(10,1,2,'2025-06-04','2025-06-11','Inactiva','2025-05-03 20:51:35','2025-07-04 17:25:40'),(11,1,3,'2025-05-03','2025-06-02','Inactiva','2025-05-03 20:53:27','2025-06-04 15:17:28'),(12,3,1,'2025-06-04','2025-07-04','Inactiva','2025-05-03 22:29:17','2025-08-06 17:28:56'),(13,1,2,'2025-05-03','2025-05-10','Inactiva','2025-05-03 22:56:45','2025-06-04 15:17:28'),(14,4,3,'2025-05-03','2025-06-02','Inactiva','2025-05-03 23:13:16','2025-06-04 15:17:28'),(15,10,4,'2025-05-05','2025-06-04','Inactiva','2025-05-04 12:27:20','2025-11-05 13:43:05'),(16,9,5,'2025-05-04','2025-06-03','Inactiva','2025-05-04 12:53:21','2025-06-04 15:17:28'),(17,2,2,'2025-06-04','2025-06-11','Inactiva','2025-05-04 12:53:33','2025-07-04 17:25:40'),(18,4,4,'2025-05-04','2025-06-03','Inactiva','2025-05-04 13:52:55','2025-06-04 15:17:28'),(19,15,21,'2025-05-04','2025-05-04','Inactiva','2025-05-04 14:41:05','2025-05-04 14:41:05'),(20,15,21,'2025-05-04','2026-05-04','Activa','2025-05-04 14:42:08','2025-05-04 14:59:00'),(21,4,6,'2025-06-04','2025-07-04','Inactiva','2025-06-04 15:39:21','2025-08-06 17:28:56'),(22,3,3,'2025-06-04','2025-07-04','Inactiva','2025-06-04 15:56:57','2025-08-06 17:28:56'),(23,18,3,'2025-11-05','2025-12-05','Activa','2025-07-04 17:27:14','2025-11-05 13:43:10'),(24,18,1,'2025-08-06','2025-09-05','Inactiva','2025-08-06 17:28:53','2025-11-05 13:43:05'),(25,24,11,'2025-05-05','2025-05-05','Inactiva','2025-05-05 12:43:56','2025-05-05 12:43:56'),(26,25,20,'2025-05-05','2025-05-20','Inactiva','2025-05-05 12:46:31','2025-11-05 13:43:05'),(27,26,8,'2025-05-05','2025-05-05','Inactiva','2025-05-05 13:19:47','2025-11-05 13:43:05'),(28,27,10,'2025-05-05','2025-05-05','Inactiva','2025-05-05 13:20:57','2025-11-05 13:43:05'),(29,28,3,'2025-05-05','2025-06-04','Inactiva','2025-05-05 13:28:28','2025-11-05 13:43:05'),(30,29,1,'2025-11-05','2025-11-05','Activa','2025-11-05 18:52:51','2025-11-05 18:52:51'),(31,30,21,'2025-11-05','2025-11-05','Activa','2025-11-05 18:55:36','2025-11-05 18:55:36'),(32,31,8,'2025-11-05','2025-11-05','Activa','2025-11-05 18:59:48','2025-11-05 18:59:48'),(33,32,4,'2025-11-05','2025-12-05','Activa','2025-11-05 19:23:41','2025-11-05 19:23:51'),(34,33,10,'2025-11-05','2025-12-05','Activa','2025-11-05 19:38:53','2025-11-05 19:39:07');
/*!40000 ALTER TABLE `membresias_miembro` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `miembros`
--

DROP TABLE IF EXISTS `miembros`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `miembros` (
  `id_miembro` int unsigned NOT NULL AUTO_INCREMENT,
  `dni` varchar(15) NOT NULL COMMENT 'Documento Nacional de Identidad (clave natural única)',
  `nombre` varchar(100) NOT NULL,
  `apellido` varchar(100) NOT NULL,
  `genero` enum('Masculino','Femenino','Otro','Prefiero no decir') DEFAULT NULL,
  `telefono` varchar(30) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL COMMENT 'Email del miembro (puede ser único si se usa para login futuro)',
  `fecha_registro` timestamp NULL DEFAULT CURRENT_TIMESTAMP COMMENT 'Fecha en que el miembro fue registrado en el sistema',
  `ultima_modificacion` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id_miembro`),
  UNIQUE KEY `dni` (`dni`),
  KEY `idx_miembro_dni` (`dni`),
  KEY `idx_miembro_apellido` (`apellido`)
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Clientes del gimnasio';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `miembros`
--

LOCK TABLES `miembros` WRITE;
/*!40000 ALTER TABLE `miembros` DISABLE KEYS */;
INSERT INTO `miembros` VALUES (1,'45469922','Carlos','Diaz','Masculino','11111112','carlos@gmail.com','2025-05-03 12:27:43','2025-08-14 21:56:16'),(2,'42334324','adsdasda','sadsadsads','Masculino','11111111','dsadaadasddas','2025-05-03 12:43:04','2025-05-03 12:50:05'),(3,'46176888','Ramiro','Gianello','Masculino','3804448721','ramirogianello@gmail.com','2025-05-03 22:28:41','2025-05-03 22:28:41'),(4,'442424124','adasdasdasd','dsasdasdasdad','Femenino','','','2025-05-03 23:13:01','2025-05-03 23:13:01'),(7,'324432213','asdassad','sasdaadssdsa','Masculino','3122323','sdaassda','2025-05-04 12:18:11','2025-05-04 12:18:11'),(8,'32113214242','dasadsassa','dsadsdsdsda','Femenino','sadsdasadsad','sdasdsaddsaa','2025-05-04 12:18:31','2025-05-04 12:18:31'),(9,'sadsadsa','sdadasdsad','hgfhdggd','Femenino','fdgfdgfgd','gdfgfdgfgdf','2025-05-04 12:18:49','2025-05-04 12:18:49'),(10,'fddfdfsfd','asdadssdads','fasdsfads','Femenino','adsdsads','saddsasda','2025-05-04 12:19:35','2025-05-04 12:19:35'),(12,'342243','43244','124',NULL,'','','2025-05-04 14:00:59','2025-05-04 14:00:59'),(13,'3214214','daasddsa','asddsaasd',NULL,'','','2025-05-04 14:08:33','2025-05-04 14:08:33'),(14,'14314','eqeea','asdsdasdasad',NULL,'','','2025-05-04 14:08:43','2025-05-04 14:08:43'),(15,'132312d','dasada','saddsasda',NULL,'','','2025-05-04 14:13:58','2025-05-04 14:38:06'),(18,'111111111','Pepe','Pepe',NULL,'','','2025-07-04 17:26:49','2025-07-04 17:26:49'),(19,'23351','jero','reguera',NULL,'','','2025-05-04 20:37:49','2025-05-04 20:37:49'),(20,'23434124','Roberto','Galati',NULL,'','','2025-05-05 12:20:38','2025-05-05 12:20:38'),(21,'4546','pepito','juan',NULL,'','','2025-05-05 12:23:57','2025-05-05 12:23:57'),(22,'32432443','juancito','diaz',NULL,'','','2025-05-05 12:28:25','2025-05-05 12:28:25'),(23,'4343113445','Luis','xd',NULL,'','','2025-05-05 12:32:28','2025-05-05 12:32:28'),(24,'454431','Nose','xD',NULL,'','','2025-05-05 12:43:47','2025-05-05 12:43:47'),(25,'43813543','Lucas','XDD',NULL,'','','2025-05-05 12:46:20','2025-05-05 12:46:20'),(26,'45460000','Pepo','XD',NULL,'','','2025-05-05 13:19:34','2025-05-05 13:19:34'),(27,'1233213214','xdddddddddd','xdd',NULL,'','','2025-05-05 13:20:54','2025-05-05 13:20:54'),(28,'777777777','Vegeta','777',NULL,'','','2025-05-05 13:28:16','2025-05-05 13:28:16'),(29,'456546564','leon','ocampo',NULL,'','','2025-11-05 18:52:39','2025-11-05 18:52:39'),(30,'434432324','leon','tigre',NULL,'','','2025-11-05 18:55:31','2025-11-05 18:55:31'),(31,'324414134','Tigre','Leon',NULL,'','','2025-11-05 18:59:42','2025-11-05 18:59:42'),(32,'432324342432','carlitos','tevez',NULL,'','','2025-11-05 19:23:33','2025-11-05 19:23:33'),(33,'492393230','Alan','Casas',NULL,'','','2025-11-05 19:38:26','2025-11-05 19:38:26');
/*!40000 ALTER TABLE `miembros` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pagos`
--

DROP TABLE IF EXISTS `pagos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pagos` (
  `id_pago` int unsigned NOT NULL AUTO_INCREMENT,
  `id_membresia` int unsigned NOT NULL COMMENT 'Membresía específica que se está pagando/renovando',
  `id_usuario_registro` int unsigned DEFAULT NULL COMMENT 'Usuario del sistema que registró el pago (opcional, para auditoría)',
  `fecha_pago` timestamp NULL DEFAULT CURRENT_TIMESTAMP COMMENT 'Fecha y hora exactas en que se registró el pago',
  `monto_pagado` decimal(10,2) NOT NULL COMMENT 'Cantidad de dinero recibida',
  `metodo_pago` enum('Efectivo','Tarjeta Débito','Tarjeta Crédito','Transferencia Bancaria','Mercado Pago','Otro') NOT NULL,
  `numero_comprobante` varchar(100) DEFAULT NULL COMMENT 'Número de factura, ticket o referencia de la transacción',
  `notas` text COMMENT 'Notas adicionales sobre el pago',
  PRIMARY KEY (`id_pago`),
  KEY `idx_pago_membresia` (`id_membresia`),
  KEY `idx_pago_usuario` (`id_usuario_registro`),
  KEY `idx_pago_fecha` (`fecha_pago`),
  CONSTRAINT `fk_pago_membresia` FOREIGN KEY (`id_membresia`) REFERENCES `membresias_miembro` (`id_membresia`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_pago_usuario` FOREIGN KEY (`id_usuario_registro`) REFERENCES `usuarios_sistema` (`id_usuario`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=44 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Registro de transacciones económicas de los miembros';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pagos`
--

LOCK TABLES `pagos` WRITE;
/*!40000 ALTER TABLE `pagos` DISABLE KEYS */;
INSERT INTO `pagos` VALUES (7,3,NULL,'2025-05-03 19:38:08',10000.00,'Efectivo','',''),(8,6,NULL,'2025-05-03 19:40:54',10000.00,'Efectivo','',''),(9,7,NULL,'2025-05-03 19:43:20',60000.00,'Efectivo','',''),(10,8,NULL,'2025-05-03 20:11:47',1000.00,'Efectivo','',''),(11,8,NULL,'2025-05-03 20:12:00',1000.00,'Efectivo','',''),(12,8,NULL,'2025-05-03 20:12:29',1000.00,'Efectivo','',''),(13,8,NULL,'2025-05-03 20:12:54',1.00,'Efectivo','',''),(14,1,NULL,'2025-05-03 20:17:20',30000.00,'Efectivo','',''),(15,1,NULL,'2025-05-03 20:17:45',30000.00,'Efectivo','',''),(16,1,NULL,'2025-05-03 20:17:54',1.00,'Efectivo','',''),(17,1,NULL,'2025-05-03 20:26:02',30000.00,'Tarjeta Débito','',''),(18,9,NULL,'2025-05-03 20:30:53',10000.00,'Efectivo','',''),(19,10,NULL,'2025-05-03 20:53:39',10000.00,'Efectivo','',''),(20,11,NULL,'2025-05-03 20:53:46',15000.00,'Efectivo','',''),(21,12,NULL,'2025-05-03 22:29:24',30000.00,'Efectivo','',''),(22,14,NULL,'2025-05-03 23:13:56',15000.00,'Efectivo','',''),(23,13,NULL,'2025-05-04 02:42:52',10000.00,'Efectivo','',''),(24,15,NULL,'2025-05-04 12:46:52',20000.00,'Efectivo','',''),(25,18,NULL,'2025-05-04 13:53:18',20000.00,'Efectivo','',''),(26,16,NULL,'2025-05-04 14:58:36',19000.00,'Efectivo','',''),(27,20,NULL,'2025-05-04 14:59:00',300000.00,'Efectivo','',''),(28,22,NULL,'2025-06-04 15:57:53',15000.00,'Efectivo','',''),(29,21,NULL,'2025-06-04 15:58:35',30000.00,'Efectivo','',''),(30,1,NULL,'2025-06-04 16:09:26',30000.00,'Efectivo','',''),(31,8,NULL,'2025-06-04 16:09:57',1000.00,'Efectivo','',''),(32,17,NULL,'2025-06-04 16:13:17',10000.00,'Efectivo','',''),(33,10,NULL,'2025-06-04 16:13:30',10000.00,'Efectivo','',''),(34,12,NULL,'2025-06-04 16:20:23',30000.00,'Efectivo','',''),(35,24,NULL,'2025-08-06 17:29:53',30000.00,'Efectivo','',''),(36,2,NULL,'2025-08-06 18:46:28',15000.00,'Efectivo','',''),(38,29,15,'2025-05-05 13:28:50',15000.00,'Efectivo','',''),(39,15,15,'2025-05-05 13:41:48',20000.00,'Efectivo','',''),(40,23,15,'2025-11-05 13:43:10',15000.00,'Efectivo','',''),(41,7,15,'2025-11-05 13:43:30',60000.00,'Efectivo','',''),(42,33,17,'2025-11-05 19:23:51',20000.00,'Tarjeta Crédito','',''),(43,34,17,'2025-11-05 19:39:07',20000.00,'Mercado Pago','','');
/*!40000 ALTER TABLE `pagos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `planes_membresia`
--

DROP TABLE IF EXISTS `planes_membresia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `planes_membresia` (
  `id_plan` int unsigned NOT NULL AUTO_INCREMENT,
  `nombre_plan` varchar(100) NOT NULL COMMENT 'Nombre descriptivo del plan (Ej: Mensual Full, Trimestral Mañanas)',
  `descripcion` text,
  `duracion_dias` int unsigned NOT NULL COMMENT 'Duración del plan en días (Ej: 30, 90, 365)',
  `precio` decimal(10,2) NOT NULL COMMENT 'Costo del plan',
  `fecha_creacion` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `ultima_modificacion` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id_plan`),
  UNIQUE KEY `nombre_plan` (`nombre_plan`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Tipos de suscripciones ofrecidas';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `planes_membresia`
--

LOCK TABLES `planes_membresia` WRITE;
/*!40000 ALTER TABLE `planes_membresia` DISABLE KEYS */;
INSERT INTO `planes_membresia` VALUES (1,'Musculacion Mensuales','',30,30000.00,'2025-05-02 19:52:43','2025-05-04 01:18:23'),(2,'Musculacion semanal',NULL,7,10000.00,'2025-05-02 20:08:44','2025-05-02 20:08:44'),(3,'Boxeo','',30,15000.00,'2025-05-03 03:50:32','2025-05-03 03:50:32'),(4,'Zumba','',30,20000.00,'2025-05-03 04:03:25','2025-05-03 04:03:25'),(5,'Entrenamiento Funcional','',30,19000.00,'2025-05-03 04:08:13','2025-05-03 04:08:13'),(6,'Karate','',30,30000.00,'2025-05-03 04:12:33','2025-05-03 04:12:33'),(7,'Taekwondo','',15,15000.00,'2025-05-03 04:21:46','2025-05-03 04:21:46'),(8,'Natacion','',30,50000.00,'2025-05-03 04:49:22','2025-05-03 06:07:41'),(9,'Musculacion Diario','',1,3000.00,'2025-05-03 05:02:48','2025-05-03 05:02:48'),(10,'Ping Pong','',30,20000.00,'2025-05-03 05:42:39','2025-05-03 05:42:39'),(11,'Padel','',30,60000.00,'2025-05-03 05:57:28','2025-05-03 13:12:43'),(20,'KunFu','',15,1000.00,'2025-05-03 13:13:08','2025-05-03 13:13:08'),(21,'Musculacion anual','Todo el año',365,300000.00,'2025-05-04 01:15:06','2025-05-04 14:37:52');
/*!40000 ALTER TABLE `planes_membresia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reclamos`
--

DROP TABLE IF EXISTS `reclamos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reclamos` (
  `id_reclamos` int NOT NULL AUTO_INCREMENT,
  `tipo` enum('sugerencia','reclamo') NOT NULL,
  `descripcion` text NOT NULL,
  `fecha_envio` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `estado` enum('pendiente','resuelto') NOT NULL DEFAULT 'pendiente',
  `respuesta` text,
  `fecha_respuesta` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `id_miembro` int unsigned DEFAULT NULL,
  PRIMARY KEY (`id_reclamos`),
  KEY `fk_reclamos_miembros1_idx` (`id_miembro`),
  CONSTRAINT `fk_reclamos_miembros1` FOREIGN KEY (`id_miembro`) REFERENCES `miembros` (`id_miembro`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reclamos`
--

LOCK TABLES `reclamos` WRITE;
/*!40000 ALTER TABLE `reclamos` DISABLE KEYS */;
INSERT INTO `reclamos` VALUES (1,'sugerencia','hgasdasd','2025-05-04 01:05:51','pendiente','xd','2025-11-05 16:54:29',NULL),(6,'sugerencia','xd','2025-11-05 15:40:12','resuelto','aaa','2025-11-05 16:54:45',NULL),(7,'reclamo','wddasddsa','2025-11-05 15:59:52','pendiente','hola','2025-11-05 15:59:52',NULL),(8,'reclamo','dssdadas','2025-11-05 16:03:32','pendiente','hola','2025-11-05 16:38:03',1),(9,'reclamo','dsasdasdadsadsa','2025-11-05 16:09:42','resuelto','hola','2025-11-05 16:09:42',1),(10,'sugerencia','todo el baño cagado','2025-05-05 19:53:30','resuelto','ya lo limpie','2025-05-05 19:53:46',NULL);
/*!40000 ALTER TABLE `reclamos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roles` (
  `id_rol` int unsigned NOT NULL AUTO_INCREMENT,
  `nombre_rol` enum('Administrador','Recepcionista') NOT NULL COMMENT 'Nombre único del rol (Ej: Administrador, Recepcionista)',
  `descripcion_rol` text COMMENT 'Descripción opcional de las responsabilidades del rol',
  `fecha_creacion` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id_rol`),
  UNIQUE KEY `nombre_rol` (`nombre_rol`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Roles de los usuarios del sistema';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES (1,'Administrador','Acceso a todo el Sistema','2025-05-05 03:36:00'),(2,'Recepcionista','Acceso parcial','2025-05-05 03:36:00');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios_sistema`
--

DROP TABLE IF EXISTS `usuarios_sistema`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuarios_sistema` (
  `id_usuario` int unsigned NOT NULL AUTO_INCREMENT,
  `username` varchar(50) NOT NULL COMMENT 'Nombre de usuario para login',
  `password_hash` varchar(255) NOT NULL COMMENT 'Contraseña hasheada (NUNCA guardar texto plano)',
  `nombre_completo` varchar(150) NOT NULL COMMENT 'Nombre y apellido del empleado',
  `email` varchar(100) DEFAULT NULL COMMENT 'Email del empleado (opcional, pero útil)',
  `id_rol` int unsigned NOT NULL COMMENT 'Rol del usuario en el sistema',
  `fecha_creacion` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `ultima_modificacion` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id_usuario`),
  UNIQUE KEY `username` (`username`),
  UNIQUE KEY `email_UNIQUE` (`email`),
  KEY `idx_usuario_rol` (`id_rol`),
  CONSTRAINT `fk_usuario_rol` FOREIGN KEY (`id_rol`) REFERENCES `roles` (`id_rol`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Usuarios que operan el sistema (staff)';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios_sistema`
--

LOCK TABLES `usuarios_sistema` WRITE;
/*!40000 ALTER TABLE `usuarios_sistema` DISABLE KEYS */;
INSERT INTO `usuarios_sistema` VALUES (14,'prueba','kEEmZbMZmg9/HzbVJHADKBMQBG2InCXLD0YOfr9n2kY=','xd',NULL,2,'2025-05-05 05:44:56','2025-05-05 05:45:30'),(15,'admin','A6xnQhbz4Vx2HuGl4lXwZ5U2I8iziLRFnhP5eNfIRvQ=','Carlos Diaz',NULL,1,'2025-05-05 06:34:26','2025-05-05 06:34:26'),(16,'chisguete','zchrc+X3y4HEpKVx10hdImaIUfoWMgZl3rX7LCJq4Vo=','Ramiro',NULL,2,'2025-05-05 13:36:17','2025-05-05 13:36:17'),(17,'xd','A6xnQhbz4Vx2HuGl4lXwZ5U2I8iziLRFnhP5eNfIRvQ=','Ricardo',NULL,2,'2025-11-05 18:01:29','2025-11-05 18:01:29'),(18,'ramiroDrHouse','A6xnQhbz4Vx2HuGl4lXwZ5U2I8iziLRFnhP5eNfIRvQ=','Dr House',NULL,2,'2025-05-05 19:54:43','2025-05-05 19:54:43');
/*!40000 ALTER TABLE `usuarios_sistema` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `vista_asistencia`
--

DROP TABLE IF EXISTS `vista_asistencia`;
/*!50001 DROP VIEW IF EXISTS `vista_asistencia`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vista_asistencia` AS SELECT 
 1 AS `id_asistencia`,
 1 AS `id_miembro`,
 1 AS `id_membresia`,
 1 AS `dni_miembro`,
 1 AS `nombre_miembro`,
 1 AS `apellido_miembro`,
 1 AS `fecha_ingreso`,
 1 AS `resultado`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `vista_membresias`
--

DROP TABLE IF EXISTS `vista_membresias`;
/*!50001 DROP VIEW IF EXISTS `vista_membresias`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vista_membresias` AS SELECT 
 1 AS `id_membresia`,
 1 AS `id_miembro`,
 1 AS `id_plan`,
 1 AS `dni_miembro`,
 1 AS `apellido_miembro`,
 1 AS `nombre_miembro`,
 1 AS `nombre_plan`,
 1 AS `precio_plan`,
 1 AS `duracion_dias_plan`,
 1 AS `fecha_inicio`,
 1 AS `fecha_fin`,
 1 AS `estado_membresia`,
 1 AS `fecha_registro`,
 1 AS `ultima_modificacion`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `vista_pagos`
--

DROP TABLE IF EXISTS `vista_pagos`;
/*!50001 DROP VIEW IF EXISTS `vista_pagos`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vista_pagos` AS SELECT 
 1 AS `id_pago`,
 1 AS `id_membresia`,
 1 AS `id_usuario_registro`,
 1 AS `apellido_miembro`,
 1 AS `nombre_miembro`,
 1 AS `dni_miembro`,
 1 AS `nombre_plan`,
 1 AS `monto`,
 1 AS `metodo`,
 1 AS `comprobante`,
 1 AS `fecha_pago`,
 1 AS `nombre_usuario`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `vista_reclamos`
--

DROP TABLE IF EXISTS `vista_reclamos`;
/*!50001 DROP VIEW IF EXISTS `vista_reclamos`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vista_reclamos` AS SELECT 
 1 AS `id_reclamos`,
 1 AS `tipo`,
 1 AS `descripcion`,
 1 AS `fecha_envio`,
 1 AS `estado`,
 1 AS `respuesta`,
 1 AS `fecha_respuesta`,
 1 AS `dni_miembro`*/;
SET character_set_client = @saved_cs_client;

--
-- Dumping events for database 'goatym2'
--

--
-- Dumping routines for database 'goatym2'
--

--
-- Final view structure for view `vista_asistencia`
--

/*!50001 DROP VIEW IF EXISTS `vista_asistencia`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vista_asistencia` AS select `a`.`id_asistencia` AS `id_asistencia`,`a`.`id_miembro` AS `id_miembro`,`a`.`id_membresia_valida` AS `id_membresia`,`m`.`dni` AS `dni_miembro`,`m`.`nombre` AS `nombre_miembro`,`m`.`apellido` AS `apellido_miembro`,`a`.`fecha_hora_checkin` AS `fecha_ingreso`,`a`.`resultado` AS `resultado` from ((`asistencia` `a` join `miembros` `m` on((`a`.`id_miembro` = `m`.`id_miembro`))) left join `membresias_miembro` `mm` on((`a`.`id_membresia_valida` = `mm`.`id_membresia`))) order by `a`.`fecha_hora_checkin` desc */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vista_membresias`
--

/*!50001 DROP VIEW IF EXISTS `vista_membresias`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vista_membresias` AS select `mm`.`id_membresia` AS `id_membresia`,`mm`.`id_miembro` AS `id_miembro`,`mm`.`id_plan` AS `id_plan`,`m`.`dni` AS `dni_miembro`,`m`.`apellido` AS `apellido_miembro`,`m`.`nombre` AS `nombre_miembro`,`p`.`nombre_plan` AS `nombre_plan`,`p`.`precio` AS `precio_plan`,`p`.`duracion_dias` AS `duracion_dias_plan`,`mm`.`fecha_inicio` AS `fecha_inicio`,`mm`.`fecha_fin` AS `fecha_fin`,`mm`.`estado_membresia` AS `estado_membresia`,`mm`.`fecha_registro` AS `fecha_registro`,`mm`.`ultima_modificacion` AS `ultima_modificacion` from ((`membresias_miembro` `mm` join `miembros` `m` on((`mm`.`id_miembro` = `m`.`id_miembro`))) join `planes_membresia` `p` on((`mm`.`id_plan` = `p`.`id_plan`))) order by `mm`.`ultima_modificacion` desc */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vista_pagos`
--

/*!50001 DROP VIEW IF EXISTS `vista_pagos`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vista_pagos` AS select `p`.`id_pago` AS `id_pago`,`p`.`id_membresia` AS `id_membresia`,`p`.`id_usuario_registro` AS `id_usuario_registro`,`m`.`apellido` AS `apellido_miembro`,`m`.`nombre` AS `nombre_miembro`,`m`.`dni` AS `dni_miembro`,`pm`.`nombre_plan` AS `nombre_plan`,`p`.`monto_pagado` AS `monto`,`p`.`metodo_pago` AS `metodo`,`p`.`numero_comprobante` AS `comprobante`,`p`.`fecha_pago` AS `fecha_pago`,`us`.`nombre_completo` AS `nombre_usuario` from ((((`pagos` `p` join `membresias_miembro` `mm` on((`p`.`id_membresia` = `mm`.`id_membresia`))) join `miembros` `m` on((`mm`.`id_miembro` = `m`.`id_miembro`))) join `planes_membresia` `pm` on((`mm`.`id_plan` = `pm`.`id_plan`))) left join `usuarios_sistema` `us` on((`p`.`id_usuario_registro` = `us`.`id_usuario`))) order by `p`.`fecha_pago` desc */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vista_reclamos`
--

/*!50001 DROP VIEW IF EXISTS `vista_reclamos`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vista_reclamos` AS select `r`.`id_reclamos` AS `id_reclamos`,`r`.`tipo` AS `tipo`,`r`.`descripcion` AS `descripcion`,`r`.`fecha_envio` AS `fecha_envio`,`r`.`estado` AS `estado`,`r`.`respuesta` AS `respuesta`,`r`.`fecha_respuesta` AS `fecha_respuesta`,`m`.`dni` AS `dni_miembro` from (`reclamos` `r` left join `miembros` `m` on((`r`.`id_miembro` = `m`.`id_miembro`))) order by `r`.`fecha_envio` desc */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-05-05 17:13:58
