# IMDBApplication
IMDB Application Services in .Net Core 5.0 and MS sql
![image](https://user-images.githubusercontent.com/60309326/152382575-d0d8e872-81cd-4b0b-aad1-e7bd3cdf009f.png)

GetMovieDetails-Display Movie Details
1.List all movies with actor and producer information. Return all the movies with details. Each
movie information consists of - Name, Date of Release, Producer, and all actors of the movie.

[Request]
http://localhost:5000/api/v1/IMDB/GetMovieDetails

[Response]
![image](https://user-images.githubusercontent.com/60309326/152382973-c4a5635c-0a3a-439e-8ad8-73809bf5ba19.png)

----------------------------------------------------------------------------------------------------------------------

AddEditMovieDetails-ADD
Create a movie: can choose multiple actors and a producer.

[Request]
![image](https://user-images.githubusercontent.com/60309326/152383481-4f2828df-6b01-4005-9518-dedb0fa57131.png)
[response]
![image](https://user-images.githubusercontent.com/60309326/152383592-e7831caf-306d-4bb8-bd00-abce50f64d01.png)

---------------------------------------------------------------------------------------------------------------------

AddEditMovieDetails-EDIT
Edit a movie: update any movie information (including actors and producer).

[Request]
![image](https://user-images.githubusercontent.com/60309326/152384438-7ffd0c75-60cc-4603-9cff-f07d44446eab.png)

[Response]
![image](https://user-images.githubusercontent.com/60309326/152384563-9292a5ca-7e04-4e82-a5d3-6e85db003da2.png)



