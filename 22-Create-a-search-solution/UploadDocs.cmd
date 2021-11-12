@echo off
SETLOCAL ENABLEDELAYEDEXPANSION

rem Set values for your storage account
set subscription_id=ce570160-450f-47cc-b9e5-b688725ec9e6
set azure_storage_account=ai102storageacc
set azure_storage_key=iMzsZmPVOPQtkyBW50hLJI56lnz2Uze21FFWKThv02VjVPReNNuj8St1uYDeMjhRsDOMVsyEUsMtGe+rHlv2KA==


echo Creating container...
call az storage container create --account-name !azure_storage_account! --subscription !subscription_id! --name margies --public-access blob --auth-mode key --account-key !azure_storage_key! --output none

echo Uploading files...
call az storage blob upload-batch -d margies -s data --account-name !azure_storage_account! --auth-mode key --account-key !azure_storage_key!  --output none
