class CreateFriends < ActiveRecord::Migration[8.0]
  def change
    create_table :friends do |t|
      t.string :FirstName
      t.string :LastName
      t.string :Email
    end
  end
end
