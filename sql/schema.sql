CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);
CREATE TABLE IF NOT EXISTS "Users" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Users" PRIMARY KEY AUTOINCREMENT,
    "Username" TEXT NULL
);
CREATE TABLE sqlite_sequence(name,seq);
CREATE TABLE IF NOT EXISTS "Messages" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Messages" PRIMARY KEY AUTOINCREMENT,
    "FromUserId" INTEGER NULL,
    "ToUserId" INTEGER NULL,
    "Text" TEXT NULL,
    CONSTRAINT "FK_Messages_Users_FromUserId" FOREIGN KEY ("FromUserId") REFERENCES "Users" ("Id") ON DELETE RESTRICT,
    CONSTRAINT "FK_Messages_Users_ToUserId" FOREIGN KEY ("ToUserId") REFERENCES "Users" ("Id") ON DELETE RESTRICT
);
CREATE INDEX "IX_Messages_FromUserId" ON "Messages" ("FromUserId");
CREATE INDEX "IX_Messages_ToUserId" ON "Messages" ("ToUserId");
