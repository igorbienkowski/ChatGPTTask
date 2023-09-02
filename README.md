# **ChatGPT Country API Documentation**

## **Application Description**

The ChatGPT Country API is a dynamic web service designed to provide detailed information on countries. With its rich set of features, it allows users to filter countries based on specific criteria, sort the data, and even paginate results. Whether you're seeking country data based on population, names, or codes, this API offers a robust and efficient way to access it.

Built on ASP.NET Core, it leverages the efficiency and security of modern web applications. The API sources its data from a trusted third-party service, ensuring the reliability and accuracy of the information provided. Additionally, with its well-structured endpoints, developers can seamlessly integrate this service into their applications or tools.

## **Running the Application Locally**

1. Clone the repository:
    ```bash
    git clone https://github.com/your-repo-url/ChatGPTTaskApi.git
    ```
2. Navigate to the project directory:
    ```bash
    cd ChatGPTTaskApi
    ```
3. Install the required packages:
    ```bash
    dotnet restore
    ```
4. Build and run the project:
    ```bash
    dotnet run
    ```
5. The API should now be running at `http://localhost:5000/`.

## **Usage Examples**

1. **Retrieve all countries**:
    ```http
    GET http://localhost:5000/countries
    ```

2. **Filter countries by name** (e.g., "Spain"):
    ```http
    GET http://localhost:5000/countries?filter=Spain
    ```

3. **Filter countries by maximum population** (e.g., countries with less than 50 million population):
    ```http
    GET http://localhost:5000/countries?maxPopulationInMillions=50
    ```

4. **Sort countries by name**:
    ```http
    GET http://localhost:5000/countries?sortByName=true
    ```

5. **Limit number of returned countries** (e.g., first 10 countries):
    ```http
    GET http://localhost:5000/countries?recordsLimit=10
    ```

6. **Combine filters** (e.g., countries with "an" in the name and have a population less than 40 million):
    ```http
    GET http://localhost:5000/countries?filter=an&maxPopulationInMillions=40
    ```

7. **Combine sorting and limiting** (e.g., first 5 countries, sorted by name):
    ```http
    GET http://localhost:5000/countries?sortByName=true&recordsLimit=5
    ```

8. **Filter by code** (e.g., countries with "FR" in their CCA2 or CCA3 code):
    ```http
    GET http://localhost:5000/countries?filter=FR
    ```

9. **Limiting, sorting, and filtering combined** (e.g., first 3 countries with "us" in the name, sorted by name):
    ```http
    GET http://localhost:5000/countries?filter=us&sortByName=true&recordsLimit=3
    ```

10. **Retrieve countries with a specific population range** (e.g., countries with population less than 100 million, sorted by name and limited to first 7):
    ```http
    GET http://localhost:5000/countries?maxPopulationInMillions=100&sortByName=true&recordsLimit=7
    ```