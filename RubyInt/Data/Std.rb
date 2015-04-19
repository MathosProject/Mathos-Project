module Addons

	def exec a
		_.Exec a
	end

	def int(a, b, c)
		_.Int(a, b, c)
	end

	def eval(a, b, c = "x")
		_.Eval(a, b, c)
	end

	def save(a, b, c = true)
		_.Save((c) ? Marshal.dump(a) : a, b)
	end

	def load(a, b = true)
		if b
			Marshal.restore(_.Load(a))
		else
			_.Load(a)
		end
	end

	def fact a
		_.Fact a
	end

	# for data manipulation

	def tsb(a, c = false, b = 50)
		_.ToSternBrocot(a, c, b)
	end

	def fsb a
		_.FromSternBrocot a
	end

	def csb a
		_.ToCondensedSternBrocot a
	end


	# for testing
	def time(a, b = 1000)
		_.Time(a, b)
	end
end

#Extension methods
class Object

	def save (p, c = true)
		a = RubyInt::Extension.new
	
		a.Save((c) ? Marshal.dump(self) : self, p)
	end

	# data manipulation

	def tsb(c = false, b = 50)
		a = RubyInt::Extension.new

		a.ToSternBrocot(self, c, b)
	end

	def fsb
		a = RubyInt::Extension.new

		a.FromSternBrocot self
	end

	def csb
		a = RubyInt::Extension.new

		a.ToCondensedSternBrocot self
	end
end

self.extend Addons
