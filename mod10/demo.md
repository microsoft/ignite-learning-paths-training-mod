# Demoing Live

The demo is re-executing the same tasks as done previously during deployment. Make sure the name are different (you can jus add an incrementation or something else as long as it's clear).

The demo use a mix of portal and script to show that both method are available. It worth mentioning it to your audience more then once...

Run through the demo using [hints-for-presentation.md](hints-for-presentation.md) file.

1. Create Resource Group Cloud Shell (it's already created, but that's fine)
2. Create VNET in Cloud Shell (then show them the vnet in portal)
3. Create VM as described in video and in deck
    * Navigate to your resource group
    * Click Add - Select Ubuntu 18.04 LTS
    * Use Ignite the tour subscription
    * Create unique Virtual Machine name
    * Select region (try using something local to the event)
    * Don't use Spot, Don't enable infra redundancy (just explain it)
    * Use a username and password or use a SSH key (i use ssh key and paste from my terminal)
    * Select inbound ports 22, 443, 80 (explain you can secure better in a secureity group)
    * Click Next Disks
    * Explain adding disks, disk types, do not add new disk.
    * Click Next Networking
    * Use VLAN created in step 2, explain network security groups, load balancing, etc
    * Click Next Management  
    * explain monitoring, explain RBAC via AAD, explain autoshutdown, explain backups.
    * Click Next Advanced  
    * Explain extensions, cloud init, etc.  Click review and create.
    * Explain validation process via ARM - Explain Exporting via ARM template
    * Create - Show create messages in deployment.
4. Navigate to server in resource group, SSH into VM
5. Copy contents of [deploy.sh](deploy.sh) into shell after su to root
6. update variables as described in demo instructions in the deployment script (mongo string, SQL, api, etc)
7. Run deploy script - talk through as it runs.
8. Navigate browser to real prod tailwindtraders.com
9. Delete resources