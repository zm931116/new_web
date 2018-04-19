CREATE TABLE [dbo].[food_org] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [fd_name]           VARCHAR (50)  NOT NULL,
    [fd_address]        VARCHAR (100) NOT NULL,
    [condition]      VARCHAR (50)  NULL,
    [latitude]       REAL          NOT NULL,
    [longitude]      REAL          NOT NULL,
    [available_time] VARCHAR (20)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

