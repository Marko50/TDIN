CSC=csc
DLL=-target:library
DLL_DIR=./out
SRC_DIR=./src
MKDIR=mkdir -p $(DLL_DIR)

SERVICE_DIR= $(SRC_DIR)/service

I_HOST_SERVICE_SRC= $(SERVICE_DIR)/IHostService.cs
I_HOST_SERVICE_LIB= $(DLL_DIR)/IHostService.dll

HOST_SERVICE_SRC= $(SERVICE_DIR)/HostService.cs
HOST_SERVICE_LIB = $(DLL_DIR)/HostService.dll
HOST_SERVICE_DEPS = -reference:$(I_HOST_SERVICE_LIB)

SERVER_SRC = $(SRC_DIR)/server/Server.cs
SERVER_EXE= $(DLL_DIR)/Server.exe
SERVER_DEPS= -reference:$(HOST_SERVICE_LIB) -reference:$(I_HOST_SERVICE_LIB)

CLIENT_SRC = $(SRC_DIR)/client/Client.cs
CLIENT_EXE= $(DLL_DIR)/Client.exe
CLIENT_DEPS= -reference:$(HOST_SERVICE_LIB) -reference:$(I_HOST_SERVICE_LIB)


all: $(SERVER_EXE) $(CLIENT_EXE)

$(CLIENT_EXE): $(I_HOST_SERVICE_LIB) $(HOST_SERVICE_LIB) $(CLIENT_SRC)
	@$(MKDIR)
	@$(CSC) $(CLIENT_DEPS) $(CLIENT_SRC) -out:$@
	@echo "CLIENT --------> Compiled!"

$(SERVER_EXE): $(I_HOST_SERVICE_LIB) $(HOST_SERVICE_LIB) $(SERVER_SRC)
	@$(MKDIR)
	@$(CSC) $(SERVER_DEPS) $(SERVER_SRC) -out:$@
	@echo "SERVER --------> Compiled!"

$(I_HOST_SERVICE_LIB): $(I_HOST_SERVICE_SRC)
	@$(MKDIR)
	@$(CSC) $(DLL) $^ -out:$@
	@echo "I_HOST_SERVICE --------> Compiled!"

$(HOST_SERVICE_LIB): $(I_HOST_SERVICE_LIB)
	@$(MKDIR)
	@$(CSC) $(DLL) $(HOST_SERVICE_DEPS) $(HOST_SERVICE_SRC) -out:$@
	@echo "HOST_SERVICE --------> Compiled!"

clean:
	@rm -rf $(DLL_DIR)