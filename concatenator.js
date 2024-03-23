const fs = require('fs');
const path = require('path');

// Define the folder path and extension
const folderPath = path.join(__dirname, 'src', 'Schema');
const fileExtension = '.cs'; // Change this to the desired file extension

// Function to concatenate content of all files with the given extension recursively
function concatenateFiles(folderPath, fileExtension) {
    // Initialize concatenated content
    let concatenatedContent = '';

    // Recursive function to traverse folders and concatenate files
    function traverseFolder(currentFolderPath) {
        // Get list of files and directories in the current folder
        const filesAndDirs = fs.readdirSync(currentFolderPath);

        // Iterate through each file or directory
        filesAndDirs.forEach(item => {
            const itemPath = path.join(currentFolderPath, item);

            // Check if the item is a file
            if (fs.statSync(itemPath).isFile()) {
                // If it's a file with the desired extension, read and concatenate its content
                if (item.endsWith(fileExtension)) {
                    const fileContent = fs.readFileSync(itemPath, 'utf8');
                    concatenatedContent += fileContent;
                }
            } else {
                // If it's a directory, recursively call traverseFolder with the directory path
                traverseFolder(itemPath);
            }
        });
    }

    // Start traversal from the root folder
    traverseFolder(folderPath);

    // Write the concatenated content to a markdown file
    const outputFilePath = path.join(__dirname, 'schema.md');
    fs.writeFileSync(outputFilePath, concatenatedContent);
    console.log('Concatenated content saved to schema.md');
}

// Call the function with the provided folder path and file extension
concatenateFiles(folderPath, fileExtension);
