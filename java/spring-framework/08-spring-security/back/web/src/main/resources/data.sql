-- INSERT INTO users (username, password, enabled) VALUES ('john', '12345', true);
INSERT INTO users (id, username, password, enabled)
    VALUES (1, 'john', '$2a$12$3BpGlGAuGJumJ9Y8lfoZPefWpiZUQw3d7HN8JEMBQUldSX/n39LUy', 1);
INSERT INTO authorities (user_id, name) VALUES (1, 'WRITE');
INSERT INTO authorities (user_id, name) VALUES (1, 'READ');

INSERT INTO users (id, username, password, enabled)
    VALUES (2, 'alice', '$2a$12$3BpGlGAuGJumJ9Y8lfoZPefWpiZUQw3d7HN8JEMBQUldSX/n39LUy', 1);
INSERT INTO authorities (user_id, name) VALUES (2, 'READ');

INSERT INTO users (id, username, password, enabled)
    VALUES (3, 'bob', '$2a$12$3BpGlGAuGJumJ9Y8lfoZPefWpiZUQw3d7HN8JEMBQUldSX/n39LUy', 1);
INSERT INTO authorities (user_id, name) VALUES (3, 'READ');
INSERT INTO authorities (user_id, name) VALUES (3, 'VIEW_OTHER_USERS');