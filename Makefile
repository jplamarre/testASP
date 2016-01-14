DEBUG=yes
CC=mcs
DEPS=System.Web.Http,System.Net.Http,System.Net.Http.Formatting,System.Web.Http.WebHost
PKGS=dotnet
TARGET_TYPE=library
BASEFLAGS=-pkg:$(PKGS) -target:$(TARGET_TYPE) -r:$(DEPS)
LIB=Products.dll
LIB_SRC=$(wildcard *.cs)
OUTDIR=Bin
SUB_DIRS=App_Code
OBJ=$(SRC:.c=.o)

ifeq ($(DEBUG),yes)
else
endif

all: $(LIB)
	@echo "compiling sourcres :" $(LIB_SRC) "\noutputting to :" $(OUTDIR)/$<

$(LIB): subdirs $(LIB_SRC)
	@$(CC) -out:$(OUTDIR)/$@ $(BASEFLAGS) $(LIB_SRC)

subdirs:
	@for dir in $(SUB_DIRS); do \
		$(MAKE) -C $$dir; \
	done

.PHONY: clean

clean:
		@rm -rf $(OUTDIR)/*
