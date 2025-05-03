-- MySQL dump 10.13  Distrib 8.0.42, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: goatym
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
  `id_miembro` int unsigned NOT NULL COMMENT 'Miembro que realizó el check-in',
  `fecha_hora_checkin` timestamp NULL DEFAULT CURRENT_TIMESTAMP COMMENT 'Fecha y hora exactas del intento de ingreso',
  `resultado` enum('Exitoso','Fallido_DNI_NoEncontrado','Fallido_Membresia_Vencida','Fallido_Membresia_Impaga','Fallido_Miembro_Inactivo','Fallido_Otro') NOT NULL COMMENT 'Resultado de la validación del check-in',
  `id_membresia_valida` int unsigned DEFAULT NULL COMMENT 'Opcional: ID de la membresía que permitió el acceso exitoso',
  PRIMARY KEY (`id_asistencia`),
  KEY `fk_asistencia_membresia_valida` (`id_membresia_valida`),
  KEY `idx_asistencia_miembro` (`id_miembro`),
  KEY `idx_asistencia_fecha` (`fecha_hora_checkin`),
  KEY `idx_asistencia_resultado` (`resultado`),
  CONSTRAINT `fk_asistencia_membresia_valida` FOREIGN KEY (`id_membresia_valida`) REFERENCES `membresias_miembro` (`id_membresia`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `fk_asistencia_miembro` FOREIGN KEY (`id_miembro`) REFERENCES `miembros` (`id_miembro`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Log de ingresos (check-ins) de los miembros';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `asistencia`
--

LOCK TABLES `asistencia` WRITE;
/*!40000 ALTER TABLE `asistencia` DISABLE KEYS */;
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
  `estado_membresia` enum('Activa','Vencida','Pendiente Pago','Cancelada') NOT NULL DEFAULT 'Pendiente Pago' COMMENT 'Estado actual de esta instancia de membresía',
  `fecha_registro` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `ultima_modificacion` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id_membresia`),
  KEY `idx_membresia_miembro` (`id_miembro`),
  KEY `idx_membresia_plan` (`id_plan`),
  KEY `idx_membresia_fechas` (`fecha_inicio`,`fecha_fin`),
  KEY `idx_membresia_estado` (`estado_membresia`),
  CONSTRAINT `fk_membresia_miembro` FOREIGN KEY (`id_miembro`) REFERENCES `miembros` (`id_miembro`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_membresia_plan` FOREIGN KEY (`id_plan`) REFERENCES `planes_membresia` (`id_plan`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Instancias de suscripción de los miembros a planes';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `membresias_miembro`
--

LOCK TABLES `membresias_miembro` WRITE;
/*!40000 ALTER TABLE `membresias_miembro` DISABLE KEYS */;
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
  `fecha_nacimiento` date DEFAULT NULL COMMENT 'Fecha de nacimiento',
  `genero` enum('Masculino','Femenino','Otro','Prefiero no decir') DEFAULT NULL,
  `telefono` varchar(30) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL COMMENT 'Email del miembro (puede ser único si se usa para login futuro)',
  `fecha_registro` timestamp NULL DEFAULT CURRENT_TIMESTAMP COMMENT 'Fecha en que el miembro fue registrado en el sistema',
  `estado` enum('Activo','Inactivo') NOT NULL DEFAULT 'Activo' COMMENT 'Estado general del miembro en el gimnasio',
  `ultima_modificacion` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id_miembro`),
  UNIQUE KEY `dni` (`dni`),
  UNIQUE KEY `email` (`email`),
  KEY `idx_miembro_dni` (`dni`),
  KEY `idx_miembro_apellido` (`apellido`),
  KEY `idx_miembro_estado` (`estado`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Clientes del gimnasio';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `miembros`
--

LOCK TABLES `miembros` WRITE;
/*!40000 ALTER TABLE `miembros` DISABLE KEYS */;
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Registro de transacciones económicas de los miembros';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pagos`
--

LOCK TABLES `pagos` WRITE;
/*!40000 ALTER TABLE `pagos` DISABLE KEYS */;
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
  `estado` enum('Activo','Inactivo') NOT NULL DEFAULT 'Activo' COMMENT 'Si el plan está disponible para nuevas suscripciones',
  `fecha_creacion` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `ultima_modificacion` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id_plan`),
  UNIQUE KEY `nombre_plan` (`nombre_plan`),
  KEY `idx_plan_estado` (`estado`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Tipos de suscripciones ofrecidas';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `planes_membresia`
--

LOCK TABLES `planes_membresia` WRITE;
/*!40000 ALTER TABLE `planes_membresia` DISABLE KEYS */;
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
  `id_miembros` int unsigned NOT NULL,
  `tipo` enum('sugerencia','reclamo') NOT NULL,
  `descripcion` text NOT NULL,
  `fecha_envio` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `estado` enum('pendiente','en revision','resuelto') NOT NULL,
  `respuesta` text,
  `fecha_respuesta` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id_reclamos`),
  KEY `fk_reclamos_miembros_idx` (`id_miembros`),
  CONSTRAINT `fk_reclamos_miembros` FOREIGN KEY (`id_miembros`) REFERENCES `miembros` (`id_miembro`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reclamos`
--

LOCK TABLES `reclamos` WRITE;
/*!40000 ALTER TABLE `reclamos` DISABLE KEYS */;
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
INSERT INTO `roles` VALUES (1,'Administrador','Acceso a todo el sistema','2025-05-01 17:23:47'),(2,'Recepcionista',NULL,'2025-05-01 17:23:47');
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
  `estado` enum('Activo','Inactivo') NOT NULL DEFAULT 'Activo' COMMENT 'Estado de la cuenta del usuario',
  `fecha_creacion` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `ultima_modificacion` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id_usuario`),
  UNIQUE KEY `username` (`username`),
  UNIQUE KEY `email` (`email`),
  KEY `idx_usuario_rol` (`id_rol`),
  CONSTRAINT `fk_usuario_rol` FOREIGN KEY (`id_rol`) REFERENCES `roles` (`id_rol`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Usuarios que operan el sistema (staff)';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios_sistema`
--

LOCK TABLES `usuarios_sistema` WRITE;
/*!40000 ALTER TABLE `usuarios_sistema` DISABLE KEYS */;
INSERT INTO `usuarios_sistema` VALUES (1,'admin','1234','Carlos Diaz',NULL,1,'Activo','2025-05-01 17:25:43','2025-05-01 17:25:43');
/*!40000 ALTER TABLE `usuarios_sistema` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'goatym'
--

--
-- Dumping routines for database 'goatym'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-05-01 17:03:30
