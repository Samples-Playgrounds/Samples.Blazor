#!/bin/bash

# Script to run all three Blazor Server apps with YARP Proxy

echo "Starting Blazor Server apps with YARP Proxy..."
echo ""

# Get the script directory
SCRIPT_DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"
PROJECTS_DIR="$SCRIPT_DIR/"

# Color codes
GREEN='\033[0;32m'
BLUE='\033[0;34m'
RED='\033[0;31m'
NC='\033[0m' # No Color

echo -e "${BLUE}Starting YARP Proxy on port 5000${NC}"
echo -e "${BLUE}Starting Customers app on port 5001${NC}"
echo -e "${BLUE}Starting Contacts app on port 5002${NC}"
echo ""

# Start YARP Proxy
cd "$PROJECTS_DIR/App_YARP_Proxy"
dotnet run --no-build &
PROXY_PID=$!

# Wait a moment
sleep 2

# Start Customers app
cd "$PROJECTS_DIR/App_Blazor_Customers"
dotnet run --no-build &
CUSTOMERS_PID=$!

# Wait a moment
sleep 2

# Start Contacts app
cd "$PROJECTS_DIR/App_Blazor_Contacts"
dotnet run --no-build &
CONTACTS_PID=$!

echo ""
echo -e "${GREEN}All apps started!${NC}"
echo "Press Ctrl+C to stop all services"
echo ""
echo "Access points:"
echo "  - YARP Proxy: http://localhost:5000"
echo "  - Customers:  http://localhost:5000/customers/"
echo "  - Contacts:   http://localhost:5000/contacts/"
echo ""
echo "Direct access:"
echo "  - Customers:  http://localhost:5001"
echo "  - Contacts:   http://localhost:5002"
echo ""

# Wait for Ctrl+C
trap "kill $PROXY_PID $CUSTOMERS_PID $CONTACTS_PID 2>/dev/null; exit" INT TERM

wait