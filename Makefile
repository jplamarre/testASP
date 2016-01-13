DEBUG=yes
CC=mcs
DEPS=System.Web.Http,System.Net.Http,System.Net.Http.Formatting
PKGS=dotnet
TARGET=library
BASEFLAGS=-pkg:$(PKGS) -target:$(TARGET) -r:$(DEPS)
LIB=Products.dll
LIB_SRC=$(wildcard *.cs)
OUTDIR=Bin
OBJ=$(SRC:.c=.o)

ifeq ($(DEBUG),yes)
else
endif

all: $(LIB)
	@echo "compiling sourcres :" $(LIB_SRC) "\noutputting to :" $(OUTDIR)/$<

$(LIB): $(LIB_SRC)
	@$(CC) -out:$(OUTDIR)/$@ $(BASEFLAGS) $(LIB_SRC)

.PHONY: clean

clean:
		@rm -rf $(OUTDIR)/*
