CREATE TRIGGER finales before insert on evidencias for each row set new.suma = new.ev1+new.ev2+new.ev3,
new.total = new.suma * 50 / 100;