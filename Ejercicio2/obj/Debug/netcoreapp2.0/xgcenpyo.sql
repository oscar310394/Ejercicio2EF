IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180621023935_First')
BEGIN
    CREATE TABLE [DirectorT] (
        [Id] int NOT NULL IDENTITY,
        [Nacionalidad] varchar(20) NULL,
        [Nombre] varchar(20) NULL,
        CONSTRAINT [PK_DirectorT] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180621023935_First')
BEGIN
    CREATE TABLE [Estadio] (
        [Id] int NOT NULL IDENTITY,
        [Capacidad] int NULL,
        [Ciudad] varchar(30) NULL,
        [Nombre] varchar(20) NULL,
        CONSTRAINT [PK_Estadio] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180621023935_First')
BEGIN
    CREATE TABLE [Seleccion] (
        [Id] int NOT NULL IDENTITY,
        [Confederacion] varchar(20) NULL,
        [Grupo] varchar(10) NULL,
        [IdDirectorT] int NULL,
        [Nombre] varchar(20) NULL,
        CONSTRAINT [PK_Seleccion] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_TecnicoSeleccion] FOREIGN KEY ([IdDirectorT]) REFERENCES [DirectorT] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180621023935_First')
BEGIN
    CREATE TABLE [Partido] (
        [Id] int NOT NULL IDENTITY,
        [Fecha] varchar(20) NULL,
        [IdEstadio] int NULL,
        [Local] varchar(20) NULL,
        [Marcador] int NULL,
        [Visita] varchar(20) NULL,
        CONSTRAINT [PK_Partido] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_EstadioPartido] FOREIGN KEY ([IdEstadio]) REFERENCES [Estadio] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180621023935_First')
BEGIN
    CREATE TABLE [Jugador] (
        [Id] int NOT NULL IDENTITY,
        [Altura] float NULL,
        [Club] varchar(20) NULL,
        [Fecha_Nac] varchar(10) NULL,
        [IdSel] int NULL,
        [Nombre] varchar(5) NULL,
        [Numero] int NULL,
        [Posicion] varchar(20) NULL,
        CONSTRAINT [PK_Jugador] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_SeleccionJugador] FOREIGN KEY ([IdSel]) REFERENCES [Seleccion] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180621023935_First')
BEGIN
    CREATE INDEX [IX_Jugador_IdSel] ON [Jugador] ([IdSel]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180621023935_First')
BEGIN
    CREATE INDEX [IX_Partido_IdEstadio] ON [Partido] ([IdEstadio]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180621023935_First')
BEGIN
    CREATE INDEX [IX_Seleccion_IdDirectorT] ON [Seleccion] ([IdDirectorT]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180621023935_First')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180621023935_First', N'2.0.3-rtm-10026');
END;

GO

