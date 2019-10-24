# Cleaning up the resources

Thanks to the deployment templates, it is really easy to deploy a new set of resources when needed. This allows saving money (as you won't let unused resources run unnecessarily), saving resources, and getting a clean environment whenever needed.

To delete the resources, simply delete the two resource groups that were created earlier.

1. Go to the Azure Portal.

2. In the bar on the left, select Resource Groups.

![Resource groups category](./images/2019-09-24_15-14-49.png)

3. In the `Filter by name` box, enter `mod41`.

4. Select the resource group `mod41[prefix]` where `[prefix]` was the prefix you used during the deployment.

5. In the Overview tab, select `Delete resource group`.

6. Confirm the deletion by entering the name of the resource group. 

> Deleting the resource group takes about 10 to 15 minutes.