-- CREATE TABLE accounts (
--     id VARCHAR(255) NOT NULL,
--     name VARCHAR(255) NOT NULL,
--     email VARCHAR(255) NOT NULL,
--     picture VARCHAR(225) NOT NULL
-- )

-- CREATE TABLE blogs (
--     id INT NOT NULL,
--     title VARCHAR(255) NOT NULL,
--     body VARCHAR(255) NOT NULL,
--     imgurl VARCHAR(255) NOT NULL,
--     published BOOLEAN,
--     creatorid VARCHAR(255) NOT NULL,

--     PRIMARY KEY (id)
-- )

-- CREATE TABLE comments (
--     id INT NOT NULL,
--     creatorid VARCHAR(255) NOT NULL,
--     body VARCHAR(255) NOT NULL,
--     blog INT NOT NULL,

--     PRIMARY KEY (id)
-- )