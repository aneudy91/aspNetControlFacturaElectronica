insert into TblEmpresa (NombreComercial, RazonSocial, RFC, DomicilioFiscal_calle, DomicilioFiscal_noExterior, DomicilioFiscal_colonia, DomicilioFiscal_localidad, DomicilioFiscal_municipio, DomicilioFiscal_estado, DomicilioFiscal_pais, DomicilioFiscal_codigoPostal)
values ('Empresa', 'Empresa sa de cv', 'EMPRDOSOE', 'Sanchez', '40', 'El Mango', 'Sonador', 'Villa Sonador', 'Monseño Nouel', 'Rep. Dom.', '98994')
go
insert into TblClienteEmpresa (IDEmpresa, NombreComercial, NombreContacto, RazonSocial, RFC, DomicilioFiscal_calle, DomicilioFiscal_noExterior, DomicilioFiscal_colonia, DomicilioFiscal_localidad, DomicilioFiscal_municipio, DomicilioFiscal_estado, DomicilioFiscal_pais, DomicilioFiscal_codigoPostal, CorreoEletronico, ContactoTelefono, ContactoCelular, TipoPersona)
values (1, 'Cliente 1', 'Jose Perez', 'Cliente 1 sa de cv', 'CLI894837', 'Sanchez', '40', 'El Mango', 'Sonador', 'Villa Sonador', 'Monseñor Nouel', 'Rep. Dom.', '959840', 'cliente1@gmail.com', '34322343', '3243423', '1')
go
insert into TblUsuarios (IDEmpresa, IDClienteEmpresa, Nombre, NombreCuenta, Clave)
values (1, NULL, 'Aneudy', 'aneudy91', '$s&')
go
insert into TblUsuarios (IDEmpresa, IDClienteEmpresa, Nombre, NombreCuenta, Clave)
values (NULL, 1, 'Aneudy Abreu', 'aabreu', '$s&')
go
