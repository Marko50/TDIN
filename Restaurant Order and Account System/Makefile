CSC=csc
DLL=-target:library
DLL_DIR=./out
SRC_DIR=./src
MKDIR=mkdir -p $(DLL_DIR)

LIB_DIR=$(SRC_DIR)/lib
LIB_SRC=$(wildcard $(LIB_DIR)/*cs)
LIB_DLL=$(DLL_DIR)/CentralNodeManager.dll

GUI_DIR=$(SRC_DIR)/GUI
GUI_SRC=$(wildcard $(GUI_DIR)/*/*.cs) $(wildcard $(GUI_DIR)/*/*/*.cs)
GUI_DLL=$(DLL_DIR)/gui.dll
GUI_LIBS=-reference:$(LIB_DLL)

SERVERS_DIR=$(SRC_DIR)/Servers
SERVERS_LIBS=-reference:$(GUI_DLL) -reference:$(LIB_DLL)

CENTRAL_NODE_DIR=$(SERVERS_DIR)/CentralNode
CENTRAL_NODE_SRC=$(wildcard $(CENTRAL_NODE_DIR)/*.cs)
CENTRAL_NODE_EXE=$(DLL_DIR)/CentralNode.exe

ORDER_DEALING_DIR=$(SERVERS_DIR)/OrderDealing
ORDER_DEALING_SRC=$(wildcard $(ORDER_DEALING_DIR)/*.cs)
ORDER_DEALING_DLL=$(DLL_DIR)/orderdealing.dll

BAR_MANAGER_DIR=$(ORDER_DEALING_DIR)/Bar
BAR_MANAGER_SRC=$(wildcard $(BAR_MANAGER_DIR)/*.cs)
BAR_MANAGER_EXE=$(DLL_DIR)/BarManager.exe

KITCHEN_MANAGER_DIR=$(ORDER_DEALING_DIR)/Kitchen
KITCHEN_MANAGER_SRC=$(wildcard $(KITCHEN_MANAGER_DIR)/*.cs)
KITCHEN_MANAGER_EXE=$(DLL_DIR)/KitchenManager.exe

KITCHEN_BAR_MANAGER_LIBS=$(SERVERS_LIBS) -reference:$(ORDER_DEALING_DLL)

PAYMENT_MANAGER_DIR=$(SERVERS_DIR)/Payment
PAYMENT_MANAGER_SRC=$(wildcard $(PAYMENT_MANAGER_DIR)/*.cs)
PAYMENT_MANAGER_EXE=$(DLL_DIR)/PaymentManager.exe

CLIENTS_DIR=$(SRC_DIR)/Clients
CLIENTS_SRC=$(wildcard $(CLIENTS_DIR)/*.cs)
CLIENTS_LIBS=-reference:$(GUI_DLL) -reference:$(LIB_DLL)
CLIENTS_EXE=$(DLL_DIR)/DiningRoom.exe

SRC_EXE=$(CLIENTS_EXE) $(CENTRAL_NODE_EXE) $(BAR_MANAGER_EXE) $(KITCHEN_MANAGER_EXE) $(PAYMENT_MANAGER_EXE)

all: $(SRC_EXE)

$(LIB_DLL): $(LIB_SRC)
	@$(MKDIR)
	@$(CSC) $(DLL) $^ -out:$@
	@echo "LIB --------> Compiled!"

$(GUI_DLL): $(GUI_SRC)
	@$(MKDIR)
	@$(CSC) $(DLL) $(GUI_LIBS) $^ -out:$@
	@echo "GUI --------> Compiled!"

$(ORDER_DEALING_DLL): $(ORDER_DEALING_SRC)
	@$(MKDIR)
	@$(CSC) $(DLL) $(SERVERS_LIBS) $^ -out:$@
	@echo "ORDER DEALING --------> Compiled!"

$(CLIENTS_EXE): $(LIB_DLL) $(GUI_DLL)
	@$(MKDIR)
	@$(CSC) $(CLIENTS_SRC) $(CLIENTS_LIBS) -out:$@
	@echo "CLIENTS --------> Compiled!"

$(CENTRAL_NODE_EXE): $(LIB_DLL) $(GUI_DLL)
	@$(MKDIR)
	@$(CSC) $(CENTRAL_NODE_SRC) $(SERVERS_LIBS) -out:$@
	@echo "CENTRAL_NODE_EXE --------> Compiled!"

$(KITCHEN_MANAGER_EXE): $(LIB_DLL) $(GUI_DLL) $(ORDER_DEALING_DLL)
	@$(MKDIR)
	@$(CSC) $(KITCHEN_MANAGER_SRC) $(KITCHEN_BAR_MANAGER_LIBS) -out:$@
	@echo "KITCHEN_MANAGER_EXE --------> Compiled!"

$(BAR_MANAGER_EXE): $(LIB_DLL) $(GUI_DLL) $(ORDER_DEALING_DLL)
	@$(MKDIR)
	@$(CSC) $(BAR_MANAGER_SRC) $(KITCHEN_BAR_MANAGER_LIBS) -out:$@
	@echo "BAR_MANAGER_EXE --------> Compiled!"

$(PAYMENT_MANAGER_EXE): $(LIB_DLL) $(GUI_DLL)
	@$(MKDIR)
	@$(CSC) $(PAYMENT_MANAGER_SRC) $(SERVERS_LIBS) -out:$@
	@echo "PAYMENT_MANAGER_EXE --------> Compiled!"

clean:
	@rm -rf $(LIB_DLL) $(GUI_DLL) $(ORDER_DEALING_DLL) $(CLIENTS_EXE) $(CLIENTS_EXE) $(CENTRAL_NODE_EXE) $(BAR_MANAGER_EXE) $(KITCHEN_MANAGER_EXE) $(PAYMENT_MANAGER_EXE)