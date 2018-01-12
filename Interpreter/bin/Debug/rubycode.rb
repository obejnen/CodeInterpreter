def redirect(text)file = File.open("output.txt", "w");file.puts(text);file.close;end

redirect("asd")