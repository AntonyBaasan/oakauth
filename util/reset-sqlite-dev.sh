echo "Resetting src/Web/App_Data/IdentityServer-dev.db ..."
cd src/Web/App_Data
rm IdentityServer-dev.db
cp IdentityServer-empty.db IdentityServer-dev.db
echo "Done."

