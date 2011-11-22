
EXTRA_DIST =  

# Warning: This is an automatically generated file, do not edit!

if ENABLE_DEBUG
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG"
ASSEMBLY = bin/Debug/PackageManager.dll
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = library
PROJECT_REFERENCES = 
BUILD_DIR = bin/Debug

PACKAGEMANAGER_DLL_MDB_SOURCE=bin/Debug/PackageManager.dll.mdb
PACKAGEMANAGER_DLL_MDB=$(BUILD_DIR)/PackageManager.dll.mdb

endif

if ENABLE_RELEASE
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize-
ASSEMBLY = bin/Release/PackageManager.dll
ASSEMBLY_MDB = 
COMPILE_TARGET = library
PROJECT_REFERENCES = 
BUILD_DIR = bin/Release

PACKAGEMANAGER_DLL_MDB=

endif

AL=al2
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(PACKAGEMANAGER_DLL_MDB)  

LINUX_PKGCONFIG = \
	$(PACKAGEMANAGER_PC)  


RESGEN=resgen2
	
all: $(ASSEMBLY) $(PROGRAMFILES) $(LINUX_PKGCONFIG) 

FILES = \
	src/PackageManagerAct.cs \
	src/PackageItem.cs \
	src/IPackageManagerBackend.cs \
	src/Apt/AptBackend.cs \
	src/PackageManagerFactory.cs \
	gtk-gui/generated.cs \
	src/Configuration.cs \
	gtk-gui/PackageManager.Configuration.cs \
	src/PackageManagerSelectedEventArgs.cs \
	src/Preferences.cs 

DATA_FILES = 

RESOURCES = \
	Resources/PackageManager.addin.xml \
	gtk-gui/gui.stetic 

EXTRAS = \
	packagemanager.pc.in 

REFERENCES =  \
	System \
	System.Core \
	$(DOUNIVERSE_LIBS) \
	$(DOPLATFORM_LIBS) \
	$(GTK_SHARP_20_LIBS) \
	Mono.Posix \
	$(DOPLATFORMLINUX_LIBS)

DLL_REFERENCES = 

CLEANFILES = $(PROGRAMFILES) $(LINUX_PKGCONFIG) 

include $(top_srcdir)/Makefile.include

PACKAGEMANAGER_PC = $(BUILD_DIR)/packagemanager.pc

$(eval $(call emit-deploy-wrapper,PACKAGEMANAGER_PC,packagemanager.pc))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'

$(ASSEMBLY) $(ASSEMBLY_MDB): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	mkdir -p $(shell dirname $(ASSEMBLY))
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
