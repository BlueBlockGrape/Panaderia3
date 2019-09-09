-- MySQL dump 10.13  Distrib 5.7.21, for Win64 (x86_64)
--
-- Host: localhost    Database: panaderia
-- ------------------------------------------------------
-- Server version	5.7.21-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `panaderia`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `panaderia` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `panaderia`;

--
-- Table structure for table `materia`
--

DROP TABLE IF EXISTS `materia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `materia` (
  `Id_Materia` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(50) NOT NULL,
  `Descripcion` text,
  `Existencias` int(11) NOT NULL,
  `Ultima_Mod` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id_Materia`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `materia`
--

LOCK TABLES `materia` WRITE;
/*!40000 ALTER TABLE `materia` DISABLE KEYS */;
INSERT INTO `materia` VALUES (1,'Harina','Harina blanca para panes',2,'2019-04-21 17:01:02'),(2,'Harina','Harina blanca para panes',2,'2019-05-02 03:17:53'),(4,'agua','aguas locas',4,'2019-05-06 20:31:54');
/*!40000 ALTER TABLE `materia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `panes`
--

DROP TABLE IF EXISTS `panes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `panes` (
  `Id_Pan` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(50) NOT NULL,
  `Precio` double(10,2) NOT NULL,
  `Tamaño` varchar(20) NOT NULL,
  PRIMARY KEY (`Id_Pan`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `panes`
--

LOCK TABLES `panes` WRITE;
/*!40000 ALTER TABLE `panes` DISABLE KEYS */;
INSERT INTO `panes` VALUES (1,'Concha',18.00,'Grande'),(2,'mante',13.60,'chico'),(3,'CuernoS',5.00,'Chico'),(4,'Acambarita',20.00,'Chico'),(6,'as',7.00,'Chico'),(7,'d',5.60,'dssdsdsdxzc'),(8,'Mantecadas',10.00,'Mediano'),(9,'df',45.00,'Grande'),(10,'df',78.00,'Mediano'),(11,'sr',12.00,'');
/*!40000 ALTER TABLE `panes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pertenece`
--

DROP TABLE IF EXISTS `pertenece`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pertenece` (
  `Id_Venta` int(11) NOT NULL,
  `Id_Pan` int(11) NOT NULL,
  `Nombre` varchar(50) NOT NULL,
  `Precio` double(10,2) NOT NULL,
  `Cantidad` int(11) NOT NULL,
  KEY `Id_Venta` (`Id_Venta`),
  KEY `Id_Pan` (`Id_Pan`),
  CONSTRAINT `pertenece_ibfk_1` FOREIGN KEY (`Id_Venta`) REFERENCES `ventas` (`Id_Venta`),
  CONSTRAINT `pertenece_ibfk_2` FOREIGN KEY (`Id_Pan`) REFERENCES `panes` (`Id_Pan`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pertenece`
--

LOCK TABLES `pertenece` WRITE;
/*!40000 ALTER TABLE `pertenece` DISABLE KEYS */;
INSERT INTO `pertenece` VALUES (9,1,'Concha',12.60,2),(9,2,'mante',13.60,1),(10,1,'Concha',12.60,1),(10,2,'mante',13.60,3),(10,3,'Cuerno',18.60,1),(11,1,'Concha',12.60,20),(11,2,'mante',13.60,2),(11,3,'Cuerno',18.60,1),(12,1,'Concha',12.60,30),(12,3,'Cuerno',18.60,30),(13,2,'mante',13.60,2),(14,1,'Concha',12.60,30),(15,3,'Cuerno',18.60,30),(18,1,'Concha',12.60,2),(18,2,'mante',13.60,3),(18,3,'Cuerno',18.60,2),(19,4,'Acambarita',20.00,1),(20,3,'CuernoS',5.00,5),(20,4,'Acambarita',20.00,1);
/*!40000 ALTER TABLE `pertenece` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `provee`
--

DROP TABLE IF EXISTS `provee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `provee` (
  `Id_Materia` int(11) NOT NULL,
  `Id_Proveedor` int(11) NOT NULL,
  KEY `Id_Materia` (`Id_Materia`),
  KEY `Id_Proveedor` (`Id_Proveedor`),
  CONSTRAINT `provee_ibfk_1` FOREIGN KEY (`Id_Materia`) REFERENCES `materia` (`Id_Materia`),
  CONSTRAINT `provee_ibfk_2` FOREIGN KEY (`Id_Proveedor`) REFERENCES `proveedor` (`Id_Proveedor`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `provee`
--

LOCK TABLES `provee` WRITE;
/*!40000 ALTER TABLE `provee` DISABLE KEYS */;
/*!40000 ALTER TABLE `provee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `proveedor`
--

DROP TABLE IF EXISTS `proveedor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `proveedor` (
  `Id_Proveedor` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(50) NOT NULL,
  `Domicilio` varchar(50) NOT NULL,
  `Telefono` varchar(15) NOT NULL,
  `Productos` text,
  PRIMARY KEY (`Id_Proveedor`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `proveedor`
--

LOCK TABLES `proveedor` WRITE;
/*!40000 ALTER TABLE `proveedor` DISABLE KEYS */;
INSERT INTO `proveedor` VALUES (1,'Pablo Daniel','Mansiones','4451025455','Mermelada'),(2,'getsemay','rio','4451323685','pan');
/*!40000 ALTER TABLE `proveedor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usuario` (
  `Id_Usuario` int(11) NOT NULL AUTO_INCREMENT,
  `Contraseña` varchar(50) NOT NULL,
  `Nombre` varchar(50) NOT NULL,
  `Apellidos` varchar(50) DEFAULT NULL,
  `Fecha_Nac` date NOT NULL,
  `Direccion` varchar(50) NOT NULL,
  `Administrador` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id_Usuario`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (1,'1233','Getse','Reyes','0001-01-01','Rio',1),(2,'1234','Getse','Reyes','0001-01-01','Rio',1),(3,'1111','Alan Alexis','Demetrio Chavez','1997-12-12','Jupiter',1),(4,'2222','Aaon','Castillo Castro','1998-02-20','Acambaro',0),(5,'3333','Aaron','Castillo Castro','1998-02-20','Acambaro',1),(6,'3333','Aaron','Castillo Castro','1998-02-20','Acambaro',1);
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `utiliza`
--

DROP TABLE IF EXISTS `utiliza`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `utiliza` (
  `Id_Pan` int(11) NOT NULL,
  `Id_Materia` int(11) NOT NULL,
  KEY `Id_Pan` (`Id_Pan`),
  KEY `Id_Materia` (`Id_Materia`),
  CONSTRAINT `utiliza_ibfk_1` FOREIGN KEY (`Id_Pan`) REFERENCES `panes` (`Id_Pan`),
  CONSTRAINT `utiliza_ibfk_2` FOREIGN KEY (`Id_Materia`) REFERENCES `materia` (`Id_Materia`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `utiliza`
--

LOCK TABLES `utiliza` WRITE;
/*!40000 ALTER TABLE `utiliza` DISABLE KEYS */;
/*!40000 ALTER TABLE `utiliza` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ventas`
--

DROP TABLE IF EXISTS `ventas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ventas` (
  `Id_Venta` int(11) NOT NULL AUTO_INCREMENT,
  `Id_Usuario` int(11) NOT NULL,
  `Fecha` date NOT NULL,
  `Total` double(10,2) NOT NULL,
  `Descuento` double(10,2) DEFAULT NULL,
  PRIMARY KEY (`Id_Venta`),
  KEY `Id_Usuario` (`Id_Usuario`),
  CONSTRAINT `ventas_ibfk_1` FOREIGN KEY (`Id_Usuario`) REFERENCES `usuario` (`Id_Usuario`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ventas`
--

LOCK TABLES `ventas` WRITE;
/*!40000 ALTER TABLE `ventas` DISABLE KEYS */;
INSERT INTO `ventas` VALUES (9,2,'2019-04-06',38.80,0.00),(10,1,'2019-04-07',72.00,0.00),(11,1,'2019-04-07',297.80,0.00),(12,1,'2019-04-07',936.00,0.00),(13,1,'2019-04-07',27.20,0.00),(14,1,'2019-04-07',378.00,3.50),(15,1,'2019-04-07',558.00,0.00),(18,1,'2019-04-08',103.20,0.00),(19,1,'2019-04-08',20.00,10.00),(20,1,'2019-05-06',45.00,0.00);
/*!40000 ALTER TABLE `ventas` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-05-18 10:34:49
